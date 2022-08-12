package com.cherkasy.cstulabv2;

import androidx.appcompat.app.AppCompatActivity;

import android.os.Bundle;
import android.view.View;
import android.widget.EditText;
import android.widget.TextView;

public class MainActivity extends AppCompatActivity  {
    private TextView mHelloTextView;
    private EditText mNameEditText;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);
        mHelloTextView = (TextView)findViewById(R.id.textView);
        mNameEditText = (EditText)findViewById(R.id.editText);
    }


    public void OnClick(View view) {
        mHelloTextView.setText("I DID IT !!!");
        if (mNameEditText.getText().length() == 0) {
            mHelloTextView.setText("Ви нічого не ввели в цьому полі =(!");
        } else {
            mHelloTextView.setText("Ось ваший текст: " + mNameEditText.getText());
        }
    }
}