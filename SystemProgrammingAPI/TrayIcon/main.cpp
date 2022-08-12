////////////////////////////////////////////////////////////////////////////////
// SimpleTrayWindow.cpp

#include <windows.h>
#include <shellapi.h>

#define IDM_START   32770
#define IDM_STOP    (IDM_START + 1)
#define IDM_HIDE    (IDM_START + 2)
#define IDM_SHOW    (IDM_START + 3)
#define IDM_EXIT    (IDM_START + 4)

char g_szWndname[]="SIMPLE_TRAY_WINDOW";
char g_szAppname[]="Simple Tray Window";
char g_szMsg[128];

#define ID_TRAY         900
#define WM_TRAYNOTIFY   (ID_TRAY + 1)
NOTIFYICONDATA g_tnd;

BOOL g_bVisible = TRUE;// Сразу падает в трей.
BOOL g_bRunning;

void OnStart(HWND hWnd)
{
    MessageBox(hWnd, "Start", g_szAppname, MB_OK);
}

void OnStop(HWND hWnd)
{
    MessageBox(hWnd, "Stop", g_szAppname, MB_OK);
}


BOOL TrayMessage(HWND hWnd, DWORD dwMessage, UINT uID, HICON hIcon, char* svText)
{
    g_tnd.cbSize            = sizeof(NOTIFYICONDATA);
    g_tnd.uID               = uID;
    g_tnd.hWnd              = hWnd;
    g_tnd.hIcon             = hIcon;
    g_tnd.uFlags            = NIF_MESSAGE | NIF_ICON | NIF_TIP;
    g_tnd.uCallbackMessage  = WM_TRAYNOTIFY;
    if( svText )
        lstrcpyn(g_tnd.szTip, svText, sizeof(g_tnd.szTip) / sizeof(char));
    else
        g_tnd.szTip[0]='\0';

    return Shell_NotifyIcon(dwMessage, &g_tnd);
}

void ShowPopupMenu(HWND hWnd)
{
    HMENU Menu = CreatePopupMenu();
    if( Menu )
    {
        if( IsWindowVisible(hWnd) )
            InsertMenu(Menu, -1, MF_BYPOSITION, IDM_HIDE, "Hide");
        else
            InsertMenu(Menu, -1, MF_BYPOSITION, IDM_SHOW, "Show");

        InsertMenu(Menu, -1, MF_BYPOSITION, IDM_START, "Start");
        InsertMenu(Menu, -1, MF_BYPOSITION, IDM_STOP, "Stop");
        InsertMenu(Menu, -1, MF_SEPARATOR, -1, "");
        InsertMenu(Menu, -1, MF_BYPOSITION, IDM_EXIT, "Exit");

        SetForegroundWindow(hWnd);

        POINT pt;
        GetCursorPos(&pt);
        TrackPopupMenu(Menu, TPM_BOTTOMALIGN, pt.x, pt.y, 0, hWnd, NULL);
        DestroyMenu(Menu);
    }
}

BOOL OnCommand(HWND hWnd, WPARAM wParam, LPARAM lParam)
{
    BOOL Result = TRUE;

    int wNotifyCode = HIWORD(wParam);   // Notification code.
    int wID         = LOWORD(wParam);   // Item, control, or accelerator identifier.
    HWND hwndCtl    = (HWND)lParam;     // Handle of control.

    switch( wID )   // Parse the menu selections.
    {
    case IDM_START:
        OnStart(hWnd);
        break;
    case IDM_STOP:
        OnStop(hWnd);
        break;
    case IDM_EXIT:
        if( IsWindowVisible(hWnd) )
            SendMessage(hWnd, WM_DESTROY, (WPARAM)0, (LPARAM)0);
        else
            SendMessage(hWnd, WM_CLOSE, (WPARAM)0, (LPARAM)0);
        break;
    case IDM_HIDE:
        ShowWindow(hWnd, SW_HIDE);
        g_bVisible = TRUE;
        break;
    case IDM_SHOW:
        ShowWindow(hWnd, SW_NORMAL);
        g_bVisible = FALSE;
        break;
    default:
        Result = FALSE;
    }
    return Result;
}

LRESULT CALLBACK WndProc(HWND hWnd, UINT uMsg, WPARAM wParam, LPARAM lParam)
{
    LRESULT retval = 0;

    switch( uMsg )
    {
    case WM_CREATE:
    {
        HICON Icon;
        LPCREATESTRUCT lpCreateStruct;
        lpCreateStruct = reinterpret_cast<LPCREATESTRUCT>(lParam);
        if( g_bRunning )
        {
            Icon = (HICON)LoadImage(NULL, "yes.ico", IMAGE_ICON, 0, 0, LR_LOADFROMFILE | LR_DEFAULTSIZE | LR_SHARED);
            lstrcpy(g_szMsg, "Ready");
        }
        else
        {
            Icon = (HICON)LoadImage(NULL, "cancel.ico", IMAGE_ICON, 0, 0, LR_LOADFROMFILE | LR_DEFAULTSIZE | LR_SHARED);
            lstrcpy(g_szMsg, "Idle");
        }
        if( !Icon )
            LoadIcon(lpCreateStruct->hInstance, IDI_APPLICATION);

        TrayMessage(hWnd, NIM_ADD, ID_TRAY, Icon, g_szMsg);
    }
    return 1;

    case WM_COMMAND:
        return OnCommand(hWnd, wParam, lParam);

    case WM_ACTIVATE:
    if( IsWindowVisible(hWnd) ) {
        if( g_bVisible ) ShowWindow(hWnd, SW_HIDE);
    }
    break;

    case WM_TRAYNOTIFY:
    {
        switch( lParam )
        {
        case WM_LBUTTONDBLCLK:
            if( IsWindowVisible(hWnd) )
            {
                ShowWindow(hWnd, SW_HIDE);
                g_bVisible = TRUE;
            }
            else
            {
                ShowWindow(hWnd, SW_RESTORE);
                g_bVisible = FALSE;
            }
            break;
        case WM_RBUTTONDOWN:
            ShowPopupMenu(hWnd);
        }
    }
    break;

    case WM_SIZE:
    if( SIZE_MINIMIZED == (UINT)wParam )
    {
        ShowWindow(hWnd, SW_HIDE);
        g_bVisible = TRUE;
    }
    break;

    case WM_CLOSE:
    if( IsWindowVisible(hWnd) )
        ShowWindow(hWnd, SW_HIDE);
    else
        DestroyWindow(hWnd);
    break;

    case WM_DESTROY:
        g_tnd.uFlags = 0;
        Shell_NotifyIcon(NIM_DELETE, &g_tnd);
        PostQuitMessage(0);
        break;
    default:
        retval = DefWindowProc(hWnd, uMsg, wParam, lParam);
        break;
    }
    return retval;
}

//
// Entry point.
//
int WINAPI WinMain(HINSTANCE hInstance, HINSTANCE, LPSTR, int)
{
    WNDCLASSEX wcex = {
        sizeof(WNDCLASSEX), CS_VREDRAW | CS_HREDRAW, WndProc, 0, 0, hInstance,
        LoadIcon(NULL, IDI_APPLICATION), LoadCursor(NULL, IDC_ARROW),
        (HBRUSH)(COLOR_WINDOW+1), NULL, g_szWndname, NULL,
    };

    ATOM Atom = RegisterClassEx(&wcex);
    if( !Atom ) {
        Atom = RegisterClass((LPWNDCLASS)&wcex.style);
        if( NULL == Atom ) {
            MessageBox(HWND_DESKTOP, "Cannot RegisterClass", g_szAppname, MB_OK);
            return EXIT_FAILURE;
        }
    }

    HWND hWnd = CreateWindowEx(WS_EX_APPWINDOW, MAKEINTATOM(Atom), g_szAppname,
        WS_SYSMENU | WS_CAPTION | WS_MINIMIZEBOX, CW_USEDEFAULT, 0,
        CW_USEDEFAULT, 0, HWND_DESKTOP, NULL, hInstance, NULL);
    if( !hWnd ) {
        MessageBox(HWND_DESKTOP, "Cannot CreateWindow", g_szAppname, MB_OK);
        return EXIT_FAILURE;
    }

    ShowWindow(hWnd, SW_SHOW);
    UpdateWindow(hWnd);

    MSG msg;
    while( GetMessage(&msg, NULL, 0, 0) > 0 ) {
        TranslateMessage(&msg);
        DispatchMessage(&msg);
    }
    return (int)msg.wParam;
}

////////////////////////////////////////////////////////////////////////////////
// <<eof>> SimpleTrayWindow.cpp
////////////////////////////////////////////////////////////////////////////////
