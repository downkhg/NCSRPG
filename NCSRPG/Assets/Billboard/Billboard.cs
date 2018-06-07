using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Billboard : MonoBehaviour {
    public Camera m_cCamera; //메인카메라
    public GameObject m_objQuad; //평면객체: 빌보드를 할때는 많은 버텍스가 필요없으므로 Quad를 이용한다.

    public int m_nMaxCol; //세로
    public int m_nMaxRow; //가로
    public float m_fFrameTime; //프레임당 시간

    Renderer m_cRenderer; //랜더러
    Vector2 vTexOffset; //텍스쳐uv 시작
    Vector2 vTexSize; //텍스쳐크기

    // Use this for initialization
    void Start() {
        vTexSize = new Vector2(1.0f / (float)m_nMaxRow, 1.0f / (float)m_nMaxCol);
        m_cRenderer = m_objQuad.GetComponent<Renderer>(); 
    }

    // Update is called once per frame
    void Update()
    {
        //빌보드가 카메라를 바라보도록 한다.
        transform.LookAt(m_cCamera.transform);
    }

    private void OnGUI()
    {
        if (GUI.Button(new Rect(0, 0, 100, 20), "StartEffect"))
        {
            StartCoroutine(UVChange());
        }
    }

    void SetTextureUV(Vector2 vTexOffset, Vector2 vTexSize)
    {
        m_cRenderer.material.mainTextureOffset = vTexOffset;
        m_cRenderer.material.mainTextureScale = vTexSize;
    }

    IEnumerator UVChange()
    {
        int nMaxLength = m_nMaxCol * m_nMaxRow;
        int nCount = 0;
        vTexOffset.Set(0, 0);
        SetTextureUV(vTexOffset, vTexSize);
        while (nCount < nMaxLength)
        {
            yield return new WaitForSeconds(m_fFrameTime);
            if (nCount % m_nMaxRow == 0 && nCount != 0)
            {
                //텍스쳐의 행을 변경한다.
                vTexOffset.x  = 0;
                vTexOffset.y += vTexSize.y;
            }
            else
                vTexOffset.x += vTexSize.x; //텍스쳐 시작위치를 오른쪽으로 옮김
            SetTextureUV(vTexOffset, vTexSize);
            nCount++;
        }
    }

    void MakeBillboard()
    {
        float width = 100;
        float height = 100;
        MeshFilter mf = GetComponent<MeshFilter>();
        Mesh mesh = new Mesh();
        mf.mesh = mesh;
        //4개의 점을 만듦.
        Vector3[] vertices = new Vector3[4];

        vertices[0] = new Vector3(0, 0, 0);
        vertices[1] = new Vector3(width, 0, 0);
        vertices[2] = new Vector3(0, height, 0);
        vertices[3] = new Vector3(width, height, 0);

        mesh.vertices = vertices;
        //4개의 점을 2개의 평면으로 연결시킨다.(인덱스버퍼)
        int[] tri = new int[6];

        tri[0] = 0;
        tri[1] = 2;
        tri[2] = 1;

        tri[3] = 2;
        tri[4] = 3;
        tri[5] = 1;

        mesh.triangles = tri;

        Vector3[] normals = new Vector3[4];

        normals[0] = -Vector3.forward;
        normals[1] = -Vector3.forward;
        normals[2] = -Vector3.forward;
        normals[3] = -Vector3.forward;

        //평면이 바라보는 방향을 설정
        mesh.normals = normals;

        //UV좌표설정
        Vector2[] uv = new Vector2[4];

        uv[0] = new Vector2(0, 0);
        uv[1] = new Vector2(1, 0);
        uv[2] = new Vector2(0, 1);
        uv[3] = new Vector2(1, 1);

        mesh.uv = uv;
    }
}
