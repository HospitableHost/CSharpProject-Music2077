﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Breakable : MonoBehaviour
{
    Mesh mesh;
    MeshRenderer meshRenderer;

    [HideInInspector]
    public int recursive = 2;
    [HideInInspector]
    public Vector3 breakPoint = Vector3.zero;

    private void Start()
    {
        mesh = GetComponent<MeshFilter>().mesh;
        meshRenderer = GetComponent<MeshRenderer>();
    }

    int GetCoordinate(int i)
    {
        switch (i)
        {
            case 5:
            case 7:
            case 11:
            case 15:
            case 18:
            case 19:
                return 0;
            case 4:
            case 6:
            case 10:
            case 12:
            case 20:
            case 21:
                return 1;
            case 0:
            case 2:
            case 8:
            case 13:
            case 22:
            case 23:
                return 2;
            default:
                return 3;
        }
    }

    private Mesh[] GenerateMesh(Mesh mesh, Vector3 breakPoint)
    {
        Vector3[] vertices = mesh.vertices;
        int[] triangles = mesh.triangles;
        Vector3[] normals = mesh.normals;

        float[] randoms = new float[4];
        for (int i = 0; i < 4; i++)
        {
            randoms[i] = (float)Random.Range(10f, 90f) / 100f;
        }

        Mesh[] targets = new Mesh[4];
        for (int i = 0; i < 4; i++) targets[i] = new Mesh();
        foreach (Mesh target in targets)
        {
            target.vertices = vertices;
            target.normals = normals;
            target.triangles = triangles;
            target.uv = mesh.uv;
        }

        Vector3[] vectors0 = new Vector3[24];
        for (int i = 0; i < 24; i++)
        {
            Vector3 v = targets[0].vertices[i];
            if(GetCoordinate(i) == 2)
            {
                v.x = breakPoint.x;
                v.z = breakPoint.z;
            }
            else if(GetCoordinate(i) == 3)
            {
                v.z = Mathf.Lerp(vertices[5].z, vertices[1].z, randoms[3]);
                v.x = Mathf.Lerp(vertices[5].x, vertices[1].x, randoms[3]);
            }
            else if(GetCoordinate(i) == 1)
            {
                v.x = Mathf.Lerp(vertices[5].x, vertices[4].x, randoms[0]);
                v.z = Mathf.Lerp(vertices[5].z, vertices[4].z, randoms[0]);
            }
            vectors0[i] = v;
        }
        targets[0].vertices = vectors0;

        Vector3[] vectors1 = new Vector3[24];
        for (int i = 0; i < 24; i++)
        {
            Vector3 v = targets[1].vertices[i];
            if (GetCoordinate(i) == 3)
            {
                v.x = breakPoint.x;
                v.z = breakPoint.z;
            }
            else if (GetCoordinate(i) == 2)
            {
                v.x = Mathf.Lerp(vertices[4].x, vertices[0].x, randoms[1]);
                v.z = Mathf.Lerp(vertices[4].z, vertices[0].z, randoms[1]);
            }
            else if (GetCoordinate(i) == 0)
            {
                v.x = Mathf.Lerp(vertices[5].x, vertices[4].x, randoms[0]);
                v.z = Mathf.Lerp(vertices[5].z, vertices[4].z, randoms[0]);
            }
            vectors1[i] = v;
        }
        targets[1].vertices = vectors1;

        Vector3[] vectors2 = new Vector3[24];
        for (int i = 0; i < 24; i++)
        {
            Vector3 v = targets[2].vertices[i];
            if (GetCoordinate(i) == 0)
            {
                v.x = breakPoint.x;
                v.z = breakPoint.z;
            }
            else if (GetCoordinate(i) == 1)
            {
                v.x = Mathf.Lerp(vertices[4].x, vertices[0].x, randoms[1]);
                v.z = Mathf.Lerp(vertices[4].z, vertices[0].z, randoms[1]);
            }
            else if (GetCoordinate(i) == 3)
            {
                v.x = Mathf.Lerp(vertices[1].x, vertices[0].x, randoms[2]);
                v.z = Mathf.Lerp(vertices[1].z, vertices[0].z, randoms[2]);
            }
            vectors2[i] = v;
        }
        targets[2].vertices = vectors2;

        Vector3[] vectors3 = new Vector3[24];
        for (int i = 0; i < 24; i++)
        {
            Vector3 v = targets[3].vertices[i];
            if (GetCoordinate(i) == 1)
            {
                v.x = breakPoint.x;
                v.z = breakPoint.z;
            }
            else if (GetCoordinate(i) == 0)
            {
                v.z = Mathf.Lerp(vertices[5].z, vertices[1].z, randoms[3]);
                v.x = Mathf.Lerp(vertices[5].x, vertices[1].x, randoms[3]);
            }
            else if (GetCoordinate(i) == 2)
            {
                v.x = Mathf.Lerp(vertices[1].x, vertices[0].x, randoms[2]);
                v.z = Mathf.Lerp(vertices[1].z, vertices[0].z, randoms[2]);
            }
            vectors3[i] = v;
        }
        targets[3].vertices = vectors3;

        return targets;
    }

    private Rigidbody GeneratePiece(Mesh piece_mesh, MeshRenderer meshRenderer)
    {
        GameObject piece = new GameObject("Piece");
        MeshCollider co = piece.AddComponent<MeshCollider>();
        co.convex = true;
        co.sharedMesh = piece_mesh;
        piece.transform.position = transform.position;
        piece.transform.localScale = transform.localScale;
        piece.transform.rotation = transform.rotation;
        MeshRenderer piece_render = piece.AddComponent<MeshRenderer>();
        piece_render.material = meshRenderer.material;
        piece.AddComponent<MeshFilter>().mesh = piece_mesh;
        Rigidbody rig = piece.AddComponent<Rigidbody>();
        rig.useGravity = false;
        return rig;
    }

    public void PieceUp(Vector3 breakPosition)
    {
        if (recursive <= 0)
        {
            Destroy(gameObject, 2);
            return;
        }
        Mesh[] meshes = GenerateMesh(mesh, breakPosition);
        Rigidbody[] pieces = new Rigidbody[4];
        for (int i = 0; i < 4; i++) pieces[i] = GeneratePiece(meshes[i], meshRenderer);
        Destroy(gameObject);
        for (int i = 0; i < 4; i++)
        {
            pieces[i].AddExplosionForce(400, transform.position - transform.up * 0.2f, 2);
            pieces[i].AddForce(Vector3.back * 750);
            Breakable b = pieces[i].gameObject.AddComponent<Breakable>();
            b.recursive = recursive - 1;
            switch (i)
            {
                case 0:
                    b.breakPoint = breakPosition + mesh.vertices[5] / 2;
                    break;
                case 1:
                    b.breakPoint = breakPosition + mesh.vertices[4] / 2;
                    break;
                case 2:
                    b.breakPoint = breakPosition + mesh.vertices[0] / 2;
                    break;
                case 3:
                    b.breakPoint = breakPosition + mesh.vertices[1] / 2;
                    break;
            }
            Destroy(pieces[i].gameObject, 2);
        }
    }

    private void Update()
    {
        if (transform.position.z <= -0.3f) PieceUp(breakPoint);
    }
}