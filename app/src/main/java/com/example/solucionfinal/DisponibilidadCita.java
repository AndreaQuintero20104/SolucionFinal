package com.example.solucionfinal;

import androidx.appcompat.app.AppCompatActivity;

import android.os.Bundle;
import android.widget.ArrayAdapter;
import android.widget.Spinner;
import android.widget.TextView;

import java.util.List;

public class DisponibilidadCita extends AppCompatActivity {

    TextView textCedula;
    Spinner ListEstablecimientos, ListProfesionales, ListServicio, ListFecha,ListHora;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_disponibilidad_cita);

        String valor = getIntent().getStringExtra("cedula");
        textCedula = findViewById(R.id.valor);
        textCedula.setText(valor);

        ListEstablecimientos = findViewById(R.id.ListEstablecimiento);
        ListProfesionales = findViewById(R.id.ListProfesional);
        ListServicio = findViewById(R.id.ListServicio);
        ListFecha = findViewById(R.id.ListFecha);
        ListHora = findViewById(R.id.ListHora);

        String[] lenguajes = {"Seleccione","Ruby","Java",".NET","Python","PHP","JavaScript","GO"};
        ListEstablecimientos.setAdapter(new ArrayAdapter<String>(getApplicationContext(), android.R.layout.simple_spinner_dropdown_item,lenguajes));
    }
}