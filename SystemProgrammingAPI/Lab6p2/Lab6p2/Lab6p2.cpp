// Lab6p2.cpp : Определяет точку входа для приложения.
//

#include "framework.h"
#include "Lab6p2.h"
#include <Windows.h>


#define MAX_LOADSTRING 100

// Глобальные переменные:
HINSTANCE hInst;
TCHAR szTitle[MAX_LOADSTRING];
TCHAR szWindowClass[MAX_LOADSTRING];
int i = 0, j = 0, k = 0;
LONG x;
char str[23] = "Свободных ресурсов - 8";
char str1[] = "Запущено потоков 1го типа - 0";
char str2[] = "Запущено потоков 2го типа - 0";
char str3[] = "Запущено потоков 3го типа - 0";
HWND hWnd;
HANDLE hSmphr;

// Отправить объявления функций, включенных в этот модуль кода:
ATOM				MyRegisterClass(HINSTANCE hInstance);
BOOL				InitInstance(HINSTANCE, int);
LRESULT CALLBACK	WndProc(HWND, UINT, WPARAM, LPARAM);
INT_PTR CALLBACK	About(HWND, UINT, WPARAM, LPARAM);

int APIENTRY _tWinMain(HINSTANCE hInstance,
	HINSTANCE hPrevInstance,
	LPTSTR    lpCmdLine,
	int       nCmdShow)
{
	UNREFERENCED_PARAMETER(hPrevInstance);
	UNREFERENCED_PARAMETER(lpCmdLine);

	MSG msg;
	HACCEL hAccelTable;

	// Инициализация глобальных строк
	LoadString(hInstance, IDS_APP_TITLE, szTitle, MAX_LOADSTRING);
	LoadString(hInstance, IDI_LAB6P2, szWindowClass, MAX_LOADSTRING);
	MyRegisterClass(hInstance);

	// Выполнить инициализацию приложения:
	if (!InitInstance(hInstance, nCmdShow))
	{
		return FALSE;
	}

	hAccelTable = LoadAccelerators(hInstance, MAKEINTRESOURCE(IDI_LAB6P2));

	// Цикл основного сообщения:
	while (GetMessage(&msg, NULL, 0, 0))
	{
		if (!TranslateAccelerator(msg.hwnd, hAccelTable, &msg))
		{
			TranslateMessage(&msg);
			DispatchMessage(&msg);
		}
	}

	return (int)msg.wParam;
}

ATOM MyRegisterClass(HINSTANCE hInstance)
{
	WNDCLASSEX wcex;

	wcex.cbSize = sizeof(WNDCLASSEX);

	wcex.style = CS_HREDRAW | CS_VREDRAW;
	wcex.lpfnWndProc = WndProc;
	wcex.cbClsExtra = 0;
	wcex.cbWndExtra = 0;
	wcex.hInstance = hInstance;
	wcex.hIcon = LoadIcon(hInstance, MAKEINTRESOURCE(IDI_LAB6P2));
	wcex.hCursor = LoadCursor(NULL, IDC_ARROW);
	wcex.hbrBackground = (HBRUSH)(COLOR_WINDOW + 1);
	wcex.lpszMenuName = MAKEINTRESOURCE(IDI_LAB6P2);
	wcex.lpszClassName = szWindowClass;
	wcex.hIconSm = LoadIcon(wcex.hInstance, MAKEINTRESOURCE(IDI_SMALL));

	return RegisterClassEx(&wcex);
}

BOOL InitInstance(HINSTANCE hInstance, int nCmdShow)
{
	hInst = hInstance; // Сохранить дескриптор экземпляра в глобальной переменной

	hWnd = CreateWindow(szWindowClass, szTitle, WS_OVERLAPPEDWINDOW,
		CW_USEDEFAULT, 0, CW_USEDEFAULT, 0, NULL, NULL, hInstance, NULL);

	if (!hWnd)
	{
		return FALSE;
	}

	ShowWindow(hWnd, nCmdShow);
	UpdateWindow(hWnd);

	return TRUE;
}

DWORD WINAPI Thread1(PVOID pvoid)
{
	OpenSemaphore(NULL, TRUE, "MySemaphore");
	i++;
	if (WaitForSingleObject(hSmphr, 0) == WAIT_OBJECT_0)
		ReleaseSemaphore(hSmphr, 1, &x);

	wsprintf(str, "Свободных ресурсов - %i", x + 1);
	wsprintf(str1, "Запущено потоков 1го типа - %i", i);

	InvalidateRect(hWnd, NULL, FALSE);

	return 0;
}

DWORD WINAPI Thread2(PVOID pvoid)
{
	OpenSemaphore(NULL, TRUE, "MySemaphore");
	j++;
	if (WaitForSingleObject(hSmphr, 0) == WAIT_OBJECT_0)
		ReleaseSemaphore(hSmphr, 1, &x);

	wsprintf(str, "Свободных ресурсов - %i", x + 1);
	wsprintf(str2, "Запущено потоков 2го типа - %i", j);

	InvalidateRect(hWnd, NULL, FALSE);

	return 0;
}

DWORD WINAPI Thread3(PVOID pvoid)
{
	OpenSemaphore(NULL, TRUE, "MySemaphore");
	k++;
	if (WaitForSingleObject(hSmphr, 0) == WAIT_OBJECT_0)
		ReleaseSemaphore(hSmphr, 1, &x);

	wsprintf(str, "Свободных ресурсов - %i", x + 1);
	wsprintf(str3, "Запущено потоков 3го типа - %i", k);

	InvalidateRect(hWnd, NULL, FALSE);

	return 0;
}

LRESULT CALLBACK WndProc(HWND hWnd, UINT message, WPARAM wParam, LPARAM lParam)
{
	int wmId, wmEvent;
	static PAINTSTRUCT ps;
	static HDC hdc;
	static DWORD IDThread1, IDThread2, IDThread3;
	static HANDLE hT1, hT2, hT3;

	switch (message)
	{
	case WM_CREATE:
		hSmphr = CreateSemaphore(NULL, 8, 8, "MySemaphore");
		break;
	case WM_COMMAND:
		wmId = LOWORD(wParam);
		wmEvent = HIWORD(wParam);

		switch (wmId)
		{
		case IDM_STARTTHREAD1:
			hT1 = CreateThread(NULL, 0, (LPTHREAD_START_ROUTINE)Thread1, 0, 0, &IDThread1);
			WaitForSingleObject(hSmphr, INFINITE);
			break;
		case IDM_STARTTHREAD2:
			hT2 = CreateThread(NULL, 0, (LPTHREAD_START_ROUTINE)Thread2, 0, 0, &IDThread2);
			WaitForSingleObject(hSmphr, INFINITE);
			WaitForSingleObject(hSmphr, INFINITE);
			break;
		case IDM_STARTTHREAD3:
			hT3 = CreateThread(NULL, 0, (LPTHREAD_START_ROUTINE)Thread3, 0, 0, &IDThread3);
			WaitForSingleObject(hSmphr, INFINITE);
			WaitForSingleObject(hSmphr, INFINITE);
			WaitForSingleObject(hSmphr, INFINITE);
			break;
		case IDM_FINISHTHREAD1:
			ReleaseSemaphore(hSmphr, 1, &x);
			TerminateThread(hT1, 0);
			i--;
			wsprintf(str, "Свободных ресурсов - %i", x + 1);
			wsprintf(str1, "Запущено потоков 1го типа - %i", i);
			InvalidateRect(hWnd, NULL, FALSE);
			break;
		case IDM_FINISHTHREAD2:
			ReleaseSemaphore(hSmphr, 2, &x);
			TerminateThread(hT2, 0);
			j--;
			wsprintf(str, "Свободных ресурсов - %i", x + 2);
			wsprintf(str2, "Запущено потоков 2го типа - %i", j);
			InvalidateRect(hWnd, NULL, FALSE);
			break;
		case IDM_FINISHTHREAD3:
			ReleaseSemaphore(hSmphr, 3, &x);
			TerminateThread(hT3, 0);
			k--;
			wsprintf(str, "Свободных ресурсов - %i", x + 3);
			wsprintf(str3, "Запущено потоков 3го типа - %i", k);
			InvalidateRect(hWnd, NULL, FALSE);
			break;
		case IDM_ABOUT:
			DialogBox(hInst, MAKEINTRESOURCE(IDD_ABOUTBOX), hWnd, About);
			break;
		case IDM_EXIT:
			DestroyWindow(hWnd);
			break;
		default:
			return DefWindowProc(hWnd, message, wParam, lParam);
		}
		break;
	case WM_PAINT:
		hdc = BeginPaint(hWnd, &ps);
		RECT rt;
		GetClientRect(hWnd, &rt);
		TextOut(hdc, 350, 50, str, strlen(str));
		TextOut(hdc, 75, 50, str1, strlen(str1));
		TextOut(hdc, 75, 75, str2, strlen(str2));
		TextOut(hdc, 75, 100, str3, strlen(str3));
		EndPaint(hWnd, &ps);
		break;
	case WM_DESTROY:
		PostQuitMessage(0);
		break;
	default:
		return DefWindowProc(hWnd, message, wParam, lParam);
	}
	return 0;
}

// Обработчик сообщений для окна "О программе".
INT_PTR CALLBACK About(HWND hDlg, UINT message, WPARAM wParam, LPARAM lParam)
{
	UNREFERENCED_PARAMETER(lParam);
	switch (message)
	{
	case WM_INITDIALOG:
		return (INT_PTR)TRUE;

	case WM_COMMAND:
		if (LOWORD(wParam) == IDOK || LOWORD(wParam) == IDCANCEL)
		{
			EndDialog(hDlg, LOWORD(wParam));
			return (INT_PTR)TRUE;
		}
		break;
	}
	return (INT_PTR)FALSE;
}
