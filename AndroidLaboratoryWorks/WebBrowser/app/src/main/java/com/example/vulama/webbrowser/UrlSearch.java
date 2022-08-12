package com.example.vulama.webbrowser;

import android.app.AlertDialog;
import android.app.ProgressDialog;
import android.content.Context;
import android.content.Intent;
import android.graphics.Bitmap;
import android.graphics.Color;
import android.graphics.drawable.ColorDrawable;
import android.os.Handler;
import android.support.annotation.NonNull;
import android.support.design.widget.NavigationView;
import android.support.v4.view.GravityCompat;
import android.support.v4.widget.DrawerLayout;
import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.text.InputType;
import android.text.TextUtils;
import android.util.Log;
import android.view.KeyEvent;
import android.view.MenuItem;
import android.view.View;
import android.view.WindowManager;
import android.view.inputmethod.EditorInfo;
import android.view.inputmethod.InputMethodManager;
import android.webkit.WebChromeClient;
import android.webkit.WebSettings;
import android.webkit.WebView;
import android.webkit.WebViewClient;
import android.widget.Button;
import android.widget.EditText;
import android.widget.ProgressBar;
import android.widget.RelativeLayout;
import android.widget.TextView;
import android.widget.Toast;

import com.pedromassango.doubleclick.DoubleClick;
import com.pedromassango.doubleclick.DoubleClickListener;

import java.io.BufferedReader;
import java.io.FileNotFoundException;
import java.io.IOException;
import java.io.InputStream;
import java.io.InputStreamReader;
import java.io.OutputStreamWriter;
import java.text.DateFormat;
import java.text.SimpleDateFormat;
import java.util.ArrayList;
import java.util.Date;

public class UrlSearch extends AppCompatActivity implements View.OnClickListener{

    //declaring every variable/object that is needed in this scope

    private ProgressBar progressBar;
    private Button SearchUrlButton;
    private EditText UrlInput;
    private Button HomeButton;
    private WebView SearchWebAddress;
    private Button button;
    String url="https://www.google.com";
    boolean FirstUse;
    private DrawerLayout drawer;
    private int a=0;

    //method onCreate is deployed on the first opening of the activity

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        FirstUse=true;

        //only one instruction in this case because other one is in if-else structure

        super.onCreate(savedInstanceState);

        //if incognito mode is deployed we change colors and icons of search bar in a view

        if(Read(UrlSearch.this,"incognito.txt").equals("1")){
            setContentView(R.layout.activity_url_search_black);
            UrlInput=(EditText)findViewById(R.id.input_search_url);
            UrlInput.setBackgroundColor(Color.BLACK);
            UrlInput.setTextColor(Color.WHITE);

            button=(Button)findViewById(R.id.button);
            SearchUrlButton=(Button)findViewById(R.id.search_url_button);
            HomeButton=(Button)findViewById(R.id.home_button);

            button.setBackgroundResource(R.drawable.ic_more_horiz_white_24dp);
            HomeButton.setBackgroundResource(R.drawable.ic_home_white_24dp);
            SearchUrlButton.setBackgroundResource(R.drawable.ic_search_white_24dp);
        }
        //else we just use standard layout

        else{
            setContentView(R.layout.activity_url_search);
        }

        //initializing objects

        button=(Button)findViewById(R.id.button);
        SearchUrlButton=(Button)findViewById(R.id.search_url_button);
        UrlInput=(EditText)findViewById(R.id.input_search_url);
        HomeButton=(Button)findViewById(R.id.home_button);
        SearchWebAddress=(WebView)findViewById(R.id.SearchWebSite);
        progressBar=(ProgressBar)findViewById(R.id.progressBar);
        url=getIntent().getExtras().get("url_address").toString();
        UrlInput.setText(url);

        //using method so we have search button instead of enter button on our keyboard

        UrlInput.setImeOptions(EditorInfo.IME_ACTION_SEARCH);
        UrlInput.setOnEditorActionListener(new TextView.OnEditorActionListener() {
            @Override
            public boolean onEditorAction(TextView v, int actionId, KeyEvent event) {
                if(actionId== EditorInfo.IME_ACTION_SEARCH){
                    SearchWebAddres();
                    return true;
                }
                return false;
            }
        });

        //next block of code is used to setup navigationView elements
        //declaration and initialization of drawer layout (type of layout) by his id

        drawer = findViewById(R.id.drawer_layout);
        final NavigationView navigationView = findViewById(R.id.nav_view);

        //inflating different menu based on state (homepage and standard page have different layouts)

        if(Read(UrlSearch.this,"state.txt").isEmpty()){
            navigationView.inflateMenu(R.menu.drawer_menu);
        }else{
            navigationView.inflateMenu(R.menu.drawer_menu_home);
        }

        //switch case operated by comparing id-s of the clicked items
        //get getItemId property of object gives us id that corresponds with id defined in xml file of specific item

        navigationView.setNavigationItemSelectedListener(new NavigationView.OnNavigationItemSelectedListener() {
            @Override
            public boolean onNavigationItemSelected(@NonNull MenuItem item) {
                switch (item.getItemId()) {
                    case R.id.search_engine:
                        AlertDialog.Builder b1=new AlertDialog.Builder(UrlSearch.this);
                        View v1=getLayoutInflater().inflate(R.layout.dialog_search_engine,null);
                        b1.setView(v1);
                        final AlertDialog d1 = b1.create();
                        d1.getWindow().setBackgroundDrawable(new ColorDrawable(Color.TRANSPARENT));
                        d1.show();
                        Button google = (Button) v1.findViewById(R.id.google);
                        Button bing = (Button) v1.findViewById(R.id.bing);
                        Button yahoo = (Button) v1.findViewById(R.id.yahoo);
                        google.setOnClickListener(new View.OnClickListener() {
                            @Override
                            public void onClick(View v) {
                                Write("0",UrlSearch.this,"searchengine.txt");
                                Toast.makeText(UrlSearch.this,"Search engine Google",Toast.LENGTH_SHORT).show();
                            }
                        });
                        bing.setOnClickListener(new View.OnClickListener() {
                            @Override
                            public void onClick(View v) {
                                Write("1",UrlSearch.this,"searchengine.txt");
                                Toast.makeText(UrlSearch.this,"Search engine Bing",Toast.LENGTH_SHORT).show();
                            }
                        });
                        yahoo.setOnClickListener(new View.OnClickListener() {
                            @Override
                            public void onClick(View v) {
                                Write("2",UrlSearch.this,"searchengine.txt");
                                Toast.makeText(UrlSearch.this,"Search engine Yahoo",Toast.LENGTH_SHORT).show();
                            }
                        });
                        break;


                    case R.id.homepage:
                        AlertDialog.Builder b = new AlertDialog.Builder(UrlSearch.this);
                        View v = getLayoutInflater().inflate(R.layout.dialog_layout_homepage, null);
                        final EditText address = (EditText) v.findViewById(R.id.editText);
                        b.setView(v);
                        final AlertDialog d = b.create();
                        d.getWindow().setBackgroundDrawable(new ColorDrawable(Color.TRANSPARENT));
                        d.show();
                        Button Current = (Button) v.findViewById(R.id.current);
                        Button Default = (Button) v.findViewById(R.id.def);
                        Button Entered = (Button) v.findViewById(R.id.entered);
                        Current.setOnClickListener(new View.OnClickListener() {
                            @Override
                            public void onClick(View v) {
                                Write(url, UrlSearch.this, "Homepage.txt");
                                d.dismiss();
                                a=0;
                            }
                        });
                        Default.setOnClickListener(new View.OnClickListener() {
                            @Override
                            public void onClick(View v) {
                                Write("", UrlSearch.this, "Homepage.txt");
                                d.dismiss();
                            }
                        });
                        Entered.setOnClickListener(new View.OnClickListener() {
                            @Override
                            public void onClick(View v) {
                                Write(address.getText().toString(), UrlSearch.this, "Homepage.txt");
                                d.dismiss();
                                a=0;
                            }
                        });
                        break;
                    case R.id.web:
                        break;
                    case R.id.bookmark:
                        Intent intent = new Intent(getApplicationContext(), Bookmarks.class);
                        startActivity(intent);
                        overridePendingTransition(R.anim.slide_in_left, R.anim.slide_out_right);
                        break;
                    case R.id.history:
                        intent = new Intent(getApplicationContext(), History.class);
                        startActivity(intent);
                        overridePendingTransition(R.anim.slide_in_left, R.anim.slide_out_right);
                        break;
                    case R.id.add_book:
                        AlertDialog.Builder builder = new AlertDialog.Builder(UrlSearch.this);
                        View view = getLayoutInflater().inflate(R.layout.dialog_layout, null);
                        final EditText Name = (EditText) view.findViewById(R.id.editText);
                        builder.setView(view);
                        final AlertDialog dialog = builder.create();
                        dialog.getWindow().setBackgroundDrawable(new ColorDrawable(Color.TRANSPARENT));
                        dialog.show();
                        Button Save = (Button) view.findViewById(R.id.button);
                        Save.setOnClickListener(new View.OnClickListener() {
                            @Override
                            public void onClick(View v) {
                                if (!Name.getText().toString().isEmpty()) {
                                    String temp = Read(UrlSearch.this, "NameBook.txt");
                                    temp = temp + "↨" + Name.getText().toString();
                                    Write(temp, UrlSearch.this, "NameBook.txt");
                                    temp = Read(UrlSearch.this, "AddressBook.txt");
                                    temp = temp + "↨" + url;
                                    Write(temp, UrlSearch.this, "AddressBook.txt");
                                    Toast.makeText(UrlSearch.this, "New Bookmark Added", Toast.LENGTH_SHORT).show();
                                    InputMethodManager imm = (InputMethodManager) getSystemService(getApplicationContext().INPUT_METHOD_SERVICE);
                                    imm.hideSoftInputFromWindow(Name.getWindowToken(), 0);
                                    dialog.dismiss();
                                }
                            }
                        });
                        break;
                    case R.id.incognito:
                        if(Read(UrlSearch.this,"incognito.txt").equals("0")) {
                            Write("1", UrlSearch.this, "incognito.txt");
                            Toast.makeText(UrlSearch.this,"Incognito ON",Toast.LENGTH_SHORT).show();
                            Intent intentn = getIntent();
                            finish();
                            startActivity(intentn);
                        }else{
                            Write("0", UrlSearch.this, "incognito.txt");
                            Toast.makeText(UrlSearch.this,"Incognito OFF",Toast.LENGTH_SHORT).show();
                            Intent intentn = getIntent();
                            finish();
                            startActivity(intentn);
                        }
                        break;
                }
                if((Read(UrlSearch.this,"state.txt").isEmpty())){
                    switch (item.getItemId()) {
                        case R.id.google_short:
                            Intent Open_google = new Intent(UrlSearch.this, UrlSearch.class);
                            Open_google.putExtra("url_address", "https://google.com");
                            startActivity(Open_google);
                            overridePendingTransition(R.anim.slide_in_left, R.anim.slide_out_right);
                            break;
                        case R.id.facebook_short:
                            Intent Open_facebook = new Intent(UrlSearch.this, UrlSearch.class);
                            Open_facebook.putExtra("url_address", "https://facebook.com");
                            startActivity(Open_facebook);
                            overridePendingTransition(R.anim.slide_in_left, R.anim.slide_out_right);
                            break;
                        case R.id.youtube_short:
                            Intent Open_youtube = new Intent(UrlSearch.this, UrlSearch.class);
                            Open_youtube.putExtra("url_address", "https://youtube.com");
                            startActivity(Open_youtube);
                            overridePendingTransition(R.anim.slide_in_left, R.anim.slide_out_right);
                            break;
                        case R.id.instagram_short:
                            Intent Open_instagram = new Intent(UrlSearch.this, UrlSearch.class);
                            Open_instagram.putExtra("url_address", "https://instagram.com");
                            startActivity(Open_instagram);
                            overridePendingTransition(R.anim.slide_in_left, R.anim.slide_out_right);
                            break;
                        case R.id.tsrb_short:
                            Intent Open_tsrb = new Intent(UrlSearch.this, UrlSearch.class);
                            Open_tsrb.putExtra("url_address", "http://www.tsrb.hr/");
                            startActivity(Open_tsrb);
                            overridePendingTransition(R.anim.slide_in_left, R.anim.slide_out_right);
                            break;


                    }
                }
                return true;
            }
        });

        //method that deploys progress bar when loading a page

        SearchWebAddress.setWebChromeClient(new WebChromeClient(){
            public void onProgressChanged(WebView view,int progress){
                progressBar.setProgress(progress);
                if(progress==100){
                    //when finished loading we set progress bar to invisible
                    progressBar.setVisibility(View.INVISIBLE);
                }super.onProgressChanged(view, progress);
            }
        });

        WebSettings webSettings=SearchWebAddress.getSettings();
        webSettings.setJavaScriptEnabled(true);
        SearchWebAddress.loadUrl(url);
        SearchWebAddress.setWebViewClient(new WebViewClient());

        //hiding  keyboard when loading page

        getWindow().setSoftInputMode(WindowManager.LayoutParams.SOFT_INPUT_STATE_ALWAYS_HIDDEN);
        UrlInput.setCursorVisible(false);

        //expecting clicks on different objects

        button.setOnClickListener(this);
        SearchUrlButton.setOnClickListener(this);
        HomeButton.setOnClickListener(this);
        UrlInput.setOnClickListener(this);

    }

    //method that resolves pressing back button

    @Override
    public void onBackPressed() {
        if(drawer.isDrawerOpen(GravityCompat.START)){
            drawer.closeDrawer(GravityCompat.START);
        }else{

            if(SearchWebAddress.canGoBack()){
                SearchWebAddress.goBack();
            }else{
                super.onBackPressed();
            }
        }
    }

    //method that resolves onClick events

    @Override
    public void onClick(View view) {
        if(FirstUse==true) {
            UrlInput.selectAll();
            FirstUse=false;
        }
        if(view==button){
            drawer.openDrawer(GravityCompat.START);
        }
        UrlInput.setCursorVisible(true);
        if(view==UrlInput){

        }
        if(view ==HomeButton){
            Intent homePage=new Intent(UrlSearch.this,HomeActivity.class);
            startActivity(homePage);
            overridePendingTransition(R.anim.slide_in_right,R.anim.slide_out_left);
        }
        if(view==SearchUrlButton){
            SearchWebAddres();

        }
    }

    //method that searches web addresses

    private void SearchWebAddres() {
        a=2;
        Write("",UrlSearch.this,"state.txt");
        String Url_Address=UrlInput.getText().toString();

        if(TextUtils.isEmpty(Url_Address)){
            Toast empty=Toast.makeText(UrlSearch.this,"Please enter Url or Web Address",Toast.LENGTH_LONG);
            empty.show();
        }else{

            //if input field has any of this conditions we expect that it is imputed web address

            if(!(Url_Address.contains("://"))){

                //searching web by keyword using one of the search engines (one that is selected)

                Intent search = new Intent(UrlSearch.this, UrlSearch.class);
                if(Read(UrlSearch.this,"searchengine.txt").equals("0")) {
                    search.putExtra("url_address", "https://www.google.hr/search?q=" + Url_Address + "&ie=&oe=");
                }else if(Read(UrlSearch.this,"searchengine.txt").equals("1")){
                    search.putExtra("url_address", "https://www.bing.com/search?q=" + Url_Address + "&qs=n&form=QBLH&sp=-1&pq=" + Url_Address + "&sc=8-5&sk=&cvid=3F0E1B34946D4F9DA957278A25AA9CCB");
                }else if(Read(UrlSearch.this,"searchengine.txt").equals("2")){
                    search.putExtra("url_address", "https://search.yahoo.com/search?p=" + Url_Address + "&fr=yfp-t&fp=1&toggle=1&cop=mss&ei=UTF-8");
                }
                startActivity(search);

            }else {

                //searching exact web address

                Intent search = new Intent(UrlSearch.this, UrlSearch.class);
                search.putExtra("url_address",Url_Address );
                startActivity(search);

                UrlInput.setText("");
                UrlInput.requestFocus();
            }
        }
    }

    //method that contains two methods that start when they are triggered

    public class WebViewClient extends android.webkit.WebViewClient{

        //method that is triggered when a page is loaded (100%)

        @Override
        public void onPageFinished(WebView view, String url) {
            super.onPageFinished(view, url);
            Log.i("Listener", "Finish");

            url=SearchWebAddress.getUrl();
            UrlInput.setText(url);

            //saving history if incognito mode is off

            if(Read(UrlSearch.this,"incognito.txt").equals("0")) {
                String data = Read(UrlSearch.this, "History.txt");
                Write(url + "↨" + data, UrlSearch.this, "History.txt");
                DateFormat dateFormat=new SimpleDateFormat("dd.MM.yyyy HH:mm");
                Date date =new Date();
                String tempDate=Read(UrlSearch.this,"date.txt");
                Write(dateFormat.format(date)+"↨"+tempDate,UrlSearch.this,"date.txt");
            }



            Write(url,UrlSearch.this,"LastPage.txt");
            Write("",UrlSearch.this,"state.txt");
        }

        //method that is triggered when a page is starting to load (1%)

        @Override
        public void onPageStarted(WebView view, String url, Bitmap favicon) {
            super.onPageStarted(view, url, favicon);

            if(a==1 && !(Read(UrlSearch.this,"Homepage.txt").isEmpty())){
                finish();
                Intent intent = new Intent(getApplicationContext(), UrlSearch.class);
                intent.putExtra("url_address", url);
                startActivity(intent);
                overridePendingTransition(R.anim.slide_in_left,R.anim.slide_out_right);
                a++;
            }
            a++;
        }
    }

    //function that writes string type of data into given file

    private void Write(String data, Context context, String filename) {
        try {
            OutputStreamWriter outputStreamWriter = new OutputStreamWriter(context.openFileOutput(filename, Context.MODE_PRIVATE));
            outputStreamWriter.write(data);
            outputStreamWriter.close();
        }
        catch (IOException e) {
            Log.e("Exception", "File write failed: " + e.toString());
        }
    }

    //function that retrieves string data from given file
    //retrieves line by line if there is multiple lines written inside a file

    private String Read(Context context,String filename){

        String ret = "";

        try {
            InputStream inputStream = context.openFileInput(filename);

            if ( inputStream != null ) {
                InputStreamReader inputStreamReader = new InputStreamReader(inputStream);
                BufferedReader bufferedReader = new BufferedReader(inputStreamReader);
                String receiveString = "";
                StringBuilder stringBuilder = new StringBuilder();

                while ( (receiveString = bufferedReader.readLine()) != null ) {
                    stringBuilder.append(receiveString);
                }

                inputStream.close();
                ret = stringBuilder.toString();
            }
        } catch (FileNotFoundException e) {
            e.printStackTrace();
        } catch (IOException e) {
            Log.e("login activity", "Can not read file: " + e.toString());
        }

        return ret;
    }
}
