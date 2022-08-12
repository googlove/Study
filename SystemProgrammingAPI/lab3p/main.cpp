#include <windows.h>         // подключение библиотеки с функциями API
#include "resource.h"
// Глобальные переменные:
HINSTANCE hInst; 	// Указатель приложения
LPCTSTR szWindowClass = "QWERTY";
LPCTSTR szTitle = "Третья программа";

// Предварительное описание функций
ATOM MyRegisterClass(HINSTANCE hInstance);
BOOL InitInstance(HINSTANCE, int);
LRESULT CALLBACK WndProc(HWND, UINT, WPARAM, LPARAM);

// Основная программа
int APIENTRY WinMain(HINSTANCE hInstance,
                     HINSTANCE hPrevInstance,
                     LPSTR     lpCmdLine,
                     int       nCmdShow)
{
	MSG msg;

	// Регистрация класса окна
	MyRegisterClass(hInstance);

	// Создание окна приложения
	if (!InitInstance (hInstance, nCmdShow))
	{
		return FALSE;
	}
	// Цикл обработки сообщений
	while (GetMessage(&msg, NULL, 0, 0))
	{
			TranslateMessage(&msg);
			DispatchMessage(&msg);
	}
	return msg.wParam;
}

//  FUNCTION: MyRegisterClass()
//  Регистрирует класс окна

ATOM MyRegisterClass(HINSTANCE hInstance)
{
	WNDCLASSEX wcex;
	wcex.cbSize = sizeof(WNDCLASSEX);
	wcex.style			= CS_HREDRAW | CS_VREDRAW  ;	// стиль окна
	wcex.lpfnWndProc	= (WNDPROC)WndProc; // оконная процедура
	wcex.cbClsExtra		= 0;
	wcex.cbWndExtra		= 0;
	wcex.hInstance		= hInstance;		// указатель приложения
	wcex.hIcon			= LoadIcon(NULL, IDI_HAND);		// опре-деление иконки
	wcex.hCursor		= LoadCursor(NULL, IDC_ARROW);    // опреде-ление курсора
	wcex.hbrBackground	= GetSysColorBrush(COLOR_BTNFACE);   // ус-тановка фона
	wcex.lpszMenuName	= MAKEINTRESOURCE(IDR_MENU1);		// определение меню
	wcex.lpszClassName	= szWindowClass;	// имя класса
	wcex.hIconSm		= NULL;

	return RegisterClassEx(&wcex); // регистрация класса окна
}

// FUNCTION: InitInstance(HANDLE, int)
// Создает окно приложения и сохраняет указатель приложения в переменной hInst

BOOL InitInstance(HINSTANCE hInstance, int nCmdShow)
{
   HWND hWnd;

   hInst = hInstance; // сохраняет указатель приложения в переменной hInst

   hWnd=CreateWindow(szWindowClass, // имя класса окна
 szTitle,   // имя приложения
 WS_OVERLAPPEDWINDOW | WS_HSCROLL, // стиль окна
 CW_USEDEFAULT,	// положение по Х
 CW_USEDEFAULT, 	// положение по Y
 800,    // размер по Х
 600,    // размер по Y
 NULL,	// описатель родительского окна
 NULL,       // описатель меню окна
 hInstance,  // указатель приложения
 NULL);     // параметры создания.

   if (!hWnd) // Если окно не создалось, функция возвращает FALSE
   {
      return FALSE;
   }
   ShowWindow(hWnd, nCmdShow);		// Показать окно
   UpdateWindow(hWnd);			// Обновить окно
   return TRUE;				//Успешное завершение функции
}

//  FUNCTION: WndProc(HWND, unsigned, WORD, LONG)
//  Оконная процедура. Принимает и обрабатывает все сообщения, приходящие в приложение

LRESULT CALLBACK WndProc(HWND hWnd, UINT message, WPARAM wParam, LPARAM lParam)
{
	PAINTSTRUCT ps;
	HDC hdc;
	RECT rt;

	switch (message)
	{
		case WM_CREATE: // Сообщение приходит при создании окна
			break;

		case WM_PAINT:  // Перерисовать окно
			hdc = BeginPaint(hWnd, &ps);	// Начать графический вывод
			GetClientRect(hWnd, &rt); // Область окна для рисования

			TEXTMETRIC tm;
			GetTextMetrics(hdc,&tm);

			Rectangle(hdc, 0, 0, rt.right/2, rt.bottom/2);
			Rectangle(hdc, rt.right/2, 0, rt.right, rt.bottom/2);
			Rectangle(hdc, 0, rt.bottom/2, rt.right/2, rt.bottom);
			Rectangle(hdc, rt.right/2, rt.bottom/2, rt.right, rt.bottom);


			EndPaint(hWnd, &ps);	// Закончить графический вывод
			break;

		case WM_COMMAND:
			if(LOWORD(wParam) == IDR_MENU1)
               MessageBox(NULL, "Круто!:)", "Powered by flame4ost", MB_OK);
			break;

		case WM_DESTROY: // Завершение работы
			 PostQuitMessage(0);
			break;
		default:
// Обработка сообщений, которые не обработаны пользователем
			return DefWindowProc(hWnd, message, wParam, lParam);
   }
return 0;
}
