package com.example.solucionfinal;

import android.content.Context;
import android.widget.Toast;

import org.json.JSONException;
import org.json.JSONObject;

import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;
import java.io.OutputStream;
import java.net.HttpURLConnection;
import java.net.URL;

public class Logica {

    public boolean IniciarSesion(Context context, String cedula, String contraseña){
        try {
            URL url = new URL("http://192.168.1.8:45455/api/usuario/inicarSesion");

            HttpURLConnection conn = null;
            conn = (HttpURLConnection) url.openConnection();
            conn.setRequestMethod("POST");
            conn.setRequestProperty("Content-Type", "application/json; utf-8");
            conn.setRequestProperty("Accept", "application/json");
            conn.setDoOutput(true);

            String jsonInputString = "{'cedula': '"+cedula+"', 'contraseña': '"+contraseña+"'}";


            try (OutputStream os = conn.getOutputStream()) {
                byte[] input = jsonInputString.getBytes("utf-8");
                os.write(input, 0, input.length);
            }

            try (BufferedReader br = new BufferedReader(
                    new InputStreamReader(conn.getInputStream(), "utf-8"))) {
                StringBuilder response = new StringBuilder();
                String responseLine = null;
                while ((responseLine = br.readLine()) != null) {
                    response.append(responseLine.trim());
                }

                String json = response.toString();
                JSONObject jsonObj = new JSONObject(json);
                boolean result = Boolean.parseBoolean(jsonObj.getString("result")) ;
                return result;

            }

        } catch (IOException | JSONException e) {
            return false    ;

        }

    }
}
