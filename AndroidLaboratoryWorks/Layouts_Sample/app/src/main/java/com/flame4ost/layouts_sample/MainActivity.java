package com.flame4ost.layouts_sample;

import android.content.Intent;
import android.support.constraint.ConstraintLayout;
import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.view.View;
import android.widget.LinearLayout;

public class MainActivity extends AppCompatActivity implements View.OnClickListener {

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);

        LinearLayout linearSample, relativeSample, tableSample, frameSample, gridSample, constraintSample, scrollSample;

        linearSample = (LinearLayout) findViewById(R.id.linearSample);
        relativeSample = (LinearLayout) findViewById(R.id.relativeSample);
        tableSample = (LinearLayout) findViewById(R.id.tableSample);
        frameSample = (LinearLayout) findViewById(R.id.frameSample);
        gridSample = (LinearLayout) findViewById(R.id.gridSample);
        constraintSample = (LinearLayout) findViewById(R.id.constraintSample);
        scrollSample = (LinearLayout) findViewById(R.id.scrollSample);

        linearSample.setOnClickListener(this);
        relativeSample.setOnClickListener(this);
        tableSample.setOnClickListener(this);
        frameSample.setOnClickListener(this);
        gridSample.setOnClickListener(this);
        constraintSample.setOnClickListener(this);
        scrollSample.setOnClickListener(this);
    }

    @Override
    public void onClick(View view) {
        Intent intent = null;

        switch (view.getId()) {
            case R.id.linearSample:
                intent = new Intent(this, LinearActivity.class);
                startActivity(intent);
                break;

            case R.id.relativeSample:
                intent = new Intent(this, RelativeActivity.class);
                startActivity(intent);
                break;

            case R.id.tableSample:
                intent = new Intent(this, TableActivity.class);
                startActivity(intent);
                break;

            case R.id.frameSample:
                intent = new Intent(this, FrameActivity.class);
                startActivity(intent);
                break;

            case R.id.gridSample:
                intent = new Intent(this, GridActivity.class);
                startActivity(intent);
                break;

            case R.id.constraintSample:
                intent = new Intent(this, ConstraintActivity.class);
                startActivity(intent);
                break;

            case R.id.scrollSample:
                intent = new Intent(this, ScrollActivity.class);
                startActivity(intent);
                break;
        }
    }
}
