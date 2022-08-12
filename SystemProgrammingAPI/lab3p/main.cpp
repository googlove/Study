#include <windows.h>         // ����������� ���������� � ��������� API
#include "resource.h"
// ���������� ����������:
HINSTANCE hInst; 	// ��������� ����������
LPCTSTR szWindowClass = "QWERTY";
LPCTSTR szTitle = "������ ���������";

// ��������������� �������� �������
ATOM MyRegisterClass(HINSTANCE hInstance);
BOOL InitInstance(HINSTANCE, int);
LRESULT CALLBACK WndProc(HWND, UINT, WPARAM, LPARAM);

// �������� ���������
int APIENTRY WinMain(HINSTANCE hInstance,
                     HINSTANCE hPrevInstance,
                     LPSTR     lpCmdLine,
                     int       nCmdShow)
{
	MSG msg;

	// ����������� ������ ����
	MyRegisterClass(hInstance);

	// �������� ���� ����������
	if (!InitInstance (hInstance, nCmdShow))
	{
		return FALSE;
	}
	// ���� ��������� ���������
	while (GetMessage(&msg, NULL, 0, 0))
	{
			TranslateMessage(&msg);
			DispatchMessage(&msg);
	}
	return msg.wParam;
}

//  FUNCTION: MyRegisterClass()
//  ������������ ����� ����

ATOM MyRegisterClass(HINSTANCE hInstance)
{
	WNDCLASSEX wcex;
	wcex.cbSize = sizeof(WNDCLASSEX);
	wcex.style			= CS_HREDRAW | CS_VREDRAW  ;	// ����� ����
	wcex.lpfnWndProc	= (WNDPROC)WndProc; // ������� ���������
	wcex.cbClsExtra		= 0;
	wcex.cbWndExtra		= 0;
	wcex.hInstance		= hInstance;		// ��������� ����������
	wcex.hIcon			= LoadIcon(NULL, IDI_HAND);		// ����-������� ������
	wcex.hCursor		= LoadCursor(NULL, IDC_ARROW);    // ������-����� �������
	wcex.hbrBackground	= GetSysColorBrush(COLOR_BTNFACE);   // ��-������� ����
	wcex.lpszMenuName	= MAKEINTRESOURCE(IDR_MENU1);		// ����������� ����
	wcex.lpszClassName	= szWindowClass;	// ��� ������
	wcex.hIconSm		= NULL;

	return RegisterClassEx(&wcex); // ����������� ������ ����
}

// FUNCTION: InitInstance(HANDLE, int)
// ������� ���� ���������� � ��������� ��������� ���������� � ���������� hInst

BOOL InitInstance(HINSTANCE hInstance, int nCmdShow)
{
   HWND hWnd;

   hInst = hInstance; // ��������� ��������� ���������� � ���������� hInst

   hWnd=CreateWindow(szWindowClass, // ��� ������ ����
 szTitle,   // ��� ����������
 WS_OVERLAPPEDWINDOW | WS_HSCROLL, // ����� ����
 CW_USEDEFAULT,	// ��������� �� �
 CW_USEDEFAULT, 	// ��������� �� Y
 800,    // ������ �� �
 600,    // ������ �� Y
 NULL,	// ��������� ������������� ����
 NULL,       // ��������� ���� ����
 hInstance,  // ��������� ����������
 NULL);     // ��������� ��������.

   if (!hWnd) // ���� ���� �� ���������, ������� ���������� FALSE
   {
      return FALSE;
   }
   ShowWindow(hWnd, nCmdShow);		// �������� ����
   UpdateWindow(hWnd);			// �������� ����
   return TRUE;				//�������� ���������� �������
}

//  FUNCTION: WndProc(HWND, unsigned, WORD, LONG)
//  ������� ���������. ��������� � ������������ ��� ���������, ���������� � ����������

LRESULT CALLBACK WndProc(HWND hWnd, UINT message, WPARAM wParam, LPARAM lParam)
{
	PAINTSTRUCT ps;
	HDC hdc;
	RECT rt;

	switch (message)
	{
		case WM_CREATE: // ��������� �������� ��� �������� ����
			break;

		case WM_PAINT:  // ������������ ����
			hdc = BeginPaint(hWnd, &ps);	// ������ ����������� �����
			GetClientRect(hWnd, &rt); // ������� ���� ��� ���������

			TEXTMETRIC tm;
			GetTextMetrics(hdc,&tm);

			Rectangle(hdc, 0, 0, rt.right/2, rt.bottom/2);
			Rectangle(hdc, rt.right/2, 0, rt.right, rt.bottom/2);
			Rectangle(hdc, 0, rt.bottom/2, rt.right/2, rt.bottom);
			Rectangle(hdc, rt.right/2, rt.bottom/2, rt.right, rt.bottom);


			EndPaint(hWnd, &ps);	// ��������� ����������� �����
			break;

		case WM_COMMAND:
			if(LOWORD(wParam) == IDR_MENU1)
               MessageBox(NULL, "�����!:)", "Powered by flame4ost", MB_OK);
			break;

		case WM_DESTROY: // ���������� ������
			 PostQuitMessage(0);
			break;
		default:
// ��������� ���������, ������� �� ���������� �������������
			return DefWindowProc(hWnd, message, wParam, lParam);
   }
return 0;
}
