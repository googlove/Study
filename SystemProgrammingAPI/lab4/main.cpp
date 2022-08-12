#if defined(UNICODE) && !defined(_UNICODE)
    #define _UNICODE
#elif defined(_UNICODE) && !defined(UNICODE)
    #define UNICODE
#endif

#include <tchar.h>
#include <windows.h>
#include <stdio.h>

#define MAX_STR_SIZE 100

/*  Declare Windows procedure  */
LRESULT CALLBACK WindowProcedure (HWND, UINT, WPARAM, LPARAM);

/*  Make the class name into a global variable  */
TCHAR szClassName[] = _T("lab4");


int WINAPI _tWinMain (HINSTANCE hThisInstance,
                    HINSTANCE hPrevInstance,
                    TCHAR* lpszArgument,
                    int nFunsterStil)

{
    HWND hwnd;               /* This is the handle for our window */
    MSG msg;            /* Here messages to the application are saved */
    WNDCLASSEX wincl;        /* Data structure for the windowclass */

    /* The Window structure */
    wincl.hInstance = hThisInstance;
    wincl.lpszClassName = szClassName;
    wincl.lpfnWndProc = WindowProcedure;      /* This function is called by windows */
    wincl.style = CS_DBLCLKS;                 /* Catch double-clicks */
    wincl.cbSize = sizeof (WNDCLASSEX);

    /* Use default icon and mouse-pointer */
    wincl.hIcon = LoadIcon (NULL, IDI_APPLICATION);
    wincl.hIconSm = LoadIcon (NULL, IDI_APPLICATION);
    wincl.hCursor = LoadCursor (NULL, IDC_ARROW);
    wincl.lpszMenuName = NULL;                 /* No menu */
    wincl.cbClsExtra = 0;                      /* No extra bytes after the window class */
    wincl.cbWndExtra = 0;                      /* structure or the window instance */
    /* Use Windows's default color as the background of the window */
    wincl.hbrBackground = (HBRUSH) COLOR_BACKGROUND;

    /* Register the window class, and if it fails quit the program */
    if (!RegisterClassEx (&wincl))
        return 0;

    /* The class is registered, let's create the program*/
    hwnd = CreateWindowEx (
        0,                   /* Extended possibilites for variation */
        szClassName,         /* Classname */
        _T("Lab4 by flame4ost"),   /* Title Text */
        WS_OVERLAPPEDWINDOW, /* default window */
        CW_USEDEFAULT,       /* Windows decides the position */
        CW_USEDEFAULT,       /* where the window ends up on the screen */
        544,                 /* The programs width */
        375,                 /* and height in pixels */
        NULL,        /* The window is a child-window to desktop */
        NULL,                /* No menu */
        hThisInstance,       /* Program Instance handler */
        NULL                 /* No Window Creation data */
        );

    /* Make the window visible on the screen */
    ShowWindow (hwnd, nFunsterStil);
    UpdateWindow(hwnd);

    /* Run the message loop. It will run until GetMessage() returns 0 */
    while (GetMessage (&msg, NULL, 0, 0))
    {
        /* Translate virtual-key messages into character messages */
        TranslateMessage(&msg);
        /* Send message to WindowProcedure */
        DispatchMessage(&msg);
    }

    /* The program return-value is 0 - The value that PostQuitMessage() gave */
    return msg.wParam;
}


/*  This function is called by the Windows function DispatchMessage()  */

LRESULT CALLBACK WindowProcedure(HWND hwnd, UINT msg, WPARAM wParam, LPARAM lParam)
{
    static TCHAR szText[MAX_STR_SIZE] = {_T('\0')};

    static RECT rect;
    static POINT point;

    HDC hdc;
    PAINTSTRUCT ps;

    switch (msg)
    {
    case WM_SIZE:
        GetClientRect(hwnd, &rect);
        point.x = (rect.right - rect.left) / 2;
        point.y = (rect.bottom - rect.top) / 2;
        break;

    case WM_PAINT:
        hdc = BeginPaint(hwnd, &ps);
        SetTextAlign(hdc, TA_CENTER | VTA_CENTER);
        TextOut(hdc, point.x, point.y, szText, _tcsnlen(szText, MAX_STR_SIZE));
        EndPaint(hwnd, &ps);
        break;

    case WM_MOUSEMOVE:
        _stprintf(szText, _T("Coordinates are: X = %d and Y = %d"), LOWORD(lParam), HIWORD(lParam));
        InvalidateRect(hwnd, &rect, TRUE);
        break;

    case WM_DESTROY:
        PostQuitMessage(0);
        break;

        case WM_RBUTTONDOWN:
		SetCapture(hwnd);
		break;

	case WM_RBUTTONUP:
		ReleaseCapture();
		break;

    default:
        return DefWindowProc(hwnd, msg, wParam, lParam);
    }

    return 0;
}
