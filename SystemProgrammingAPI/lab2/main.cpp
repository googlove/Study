#if defined(UNICODE) && !defined(_UNICODE)
    #define _UNICODE
#elif defined(_UNICODE) && !defined(UNICODE)
    #define UNICODE
#endif
#include <tchar.h>
 #include "resource.h"
#include <windows.h>         // ����������� ���������� � ��������� API
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

	char text[5][50];
	int mas[7];

	mas[0] = GetSystemMetrics(SM_CXSCREEN);
	mas[1] = GetSystemMetrics(SM_CYSCREEN);
	mas[2] = GetSystemMetrics(SM_CYHSCROLL);

	wsprintf(text[0], "������ ������ : %d x %d", mas[0], mas[1]);
	wsprintf(text[1], "������ �������������� ��������� ����: %d", mas[2]);

	switch (message)
	{
		case WM_CREATE: // ��������� �������� ��� �������� ����
			break;

		case WM_PAINT:  // ������������ ����
			hdc = BeginPaint(hWnd, &ps);	// ������ ����������� �����
			GetClientRect(hWnd, &rt); // ������� ���� ��� ���������

			TEXTMETRIC tm;
			GetTextMetrics(hdc,&tm);

			mas[3] = tm.tmInternalLeading;
			wsprintf(text[2], "���������� ��� �����: %d", mas[3]);

			mas[4] = rt.bottom;
			mas[5] = rt.right;
			wsprintf(text[3], "������ ���� : %d x %d", mas[4], mas[5]);

			mas[6] = GetDeviceCaps(hdc, HORZSIZE);
			wsprintf(text[4], "������ ���� : %d ��", mas[6]);

			TextOut(hdc, rt.right/20, rt.bottom/20, (LPCTSTR) text[0], strlen(text[0]));
			TextOut(hdc, rt.right/20, rt.bottom/10, (LPCTSTR) text[3], strlen(text[3]));
			TextOut(hdc, rt.right/20, rt.bottom/6.5, (LPCTSTR) text[1], strlen(text[1]));
			TextOut(hdc, rt.right/20, rt.bottom/5, (LPCTSTR) text[2], strlen(text[2]));
			TextOut(hdc, rt.right/20, rt.bottom/4, (LPCTSTR) text[4], strlen(text[4]));

			EndPaint(hWnd, &ps);	// ��������� ����������� �����
			break;

		case WM_COMMAND:
			if(LOWORD(wParam) == IDR_MENU1)
               MessageBox(NULL, "�����!:)", "Powered by flame40st", MB_OK);
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
