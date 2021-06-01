package com.example.solucionfinal;
import androidx.appcompat.app.AppCompatActivity;


import android.content.Intent;
import android.os.Bundle;

import android.os.Handler;
import android.os.StrictMode;
import android.view.View;
import android.widget.Button;
import android.widget.EditText;
import android.widget.TextView;
import android.widget.Toast;


public class MainActivity extends AppCompatActivity {
    private Handler mHandler = new Handler();
    private Button btnValidar;
    private EditText txtUsuario, txtContraseña;
    private TextView texto, valor;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);

        txtUsuario = (EditText) findViewById(R.id.TxtCedula);
        txtContraseña = (EditText) findViewById(R.id.TxtContraseña);
        btnValidar = (Button) findViewById(R.id.BtnIngresar);
        texto = findViewById(R.id.BtnRegistrarUsuario);



      StrictMode.ThreadPolicy policy = new StrictMode.ThreadPolicy.Builder().permitAll().build();

        StrictMode.setThreadPolicy(policy);

        Logica log = new Logica();

        texto.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                Intent intent = new  Intent(MainActivity.this,RegistrarUsuario.class);
                startActivity(intent);
            }
        });

        btnValidar.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                boolean resp = log.IniciarSesion(MainActivity.this,txtUsuario.getText().toString(),txtContraseña.getText().toString());
                if (resp == true){

                    Intent intent = new  Intent(MainActivity.this,DisponibilidadCita.class);
                    intent.putExtra("cedula",txtUsuario.getText().toString());
                    startActivity(intent);

                }

                Toast.makeText(MainActivity.this,Boolean.toString(resp),Toast.LENGTH_LONG).show();
            }
        });

    }






}
