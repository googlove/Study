package com.example.vulama.webbrowser;

import android.content.Context;
import android.content.Intent;
import android.graphics.drawable.Drawable;
import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.util.Log;
import android.view.View;

import java.io.IOException;
import java.io.OutputStreamWriter;

public class WelcomeActivity extends AppCompatActivity {

    //method onCreate is deployed on the first opening of the activity

    @Override
    protected void onCreate(Bundle savedInstanceState) {

        //two instructions on every onCreate method, important if you delete this part application will not work properly

        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_welcome);

        //setting default values for some of the conditions

        Write("0", WelcomeActivity.this, "incognito.txt");
        Write("https://www.google.com",WelcomeActivity.this,"LastPage.txt");
        Write("0",WelcomeActivity.this,"searchengine.txt");

        //starting another tread that does heavy lifting (loading app) while this activity is shown

        Thread th = new Thread(){
            @Override
            public void run()
            {
                try{
                    sleep(500);
                }catch(Exception e){
                    e.printStackTrace();
                }finally{
                    Intent home=new Intent(WelcomeActivity.this,HomeActivity.class);
                    startActivity(home);
                    overridePendingTransition(R.anim.slide_in_left,R.anim.slide_out_right);
                }
            }
        };
        th.start();

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
}

