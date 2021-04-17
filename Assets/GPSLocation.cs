using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GPSLocation : MonoBehaviour
{
    public float latitud;
    public float longitud;
    public float puntoLatitud;
    public float puntoLongitud;
    public static float distancia;
    public Text placeText;
    public Text gpsText;
    
    // Start is called before the first frame update
    void Start()
    {
        if(Input.location.isEnabledByUser)
        StartCoroutine(GetLocation());
    }

    private IEnumerator GetLocation()
    {
        Input.location.Start();
        while(Input.location.status == LocationServiceStatus.Initializing)
        {
            yield return new WaitForSeconds(0.5f);
        }

        latitud = Input.location.lastData.latitude;
        longitud = Input.location.lastData.longitude;
        yield break;
    }

    // Formula para sacar la distancia
    float FormulaHaversine(float lat1, float long1, float lat2, float long2)
    {
        float earthRad = 6371000;
        float lRad1 = lat1 * Mathf.Deg2Rad;
        float lRad2 = lat2 * Mathf.Deg2Rad;
        float dLat = (lat2 - lat1) * Mathf.Deg2Rad;
        float dLong = (long2 - long1) * Mathf.Deg2Rad;
        float a = Mathf.Sin(dLat / 2.0f) * Mathf.Sin(dLat / 2.0f) + 
                    Mathf.Cos(lRad1) * Mathf.Cos(lRad2) * 
                    Mathf.Sin(dLong / 2.0f) * Mathf.Sin(dLong / 2.0f);
        float c = 2 * Mathf.Atan2(Mathf.Sqrt(a), Mathf.Sqrt(1 - a));
        return earthRad * c; //en metros
    }

    // Update is called once per frame
    void Update()
    {
        latitud = Input.location.lastData.latitude;
        longitud = Input.location.lastData.longitude;
        gpsText.text = "Latitud: " + latitud + " \nLongitud: " + longitud;

        //Cancha 2 -16.587362, -68.181302
        if(latitud > (-16.587362-0.00020) && latitud < (-16.587362+0.00020) && longitud > (-68.181302-0.00020) && longitud < (-68.181302+0.00020))
        {
            puntoLatitud = -16.587362f;
            puntoLongitud = -68.181302f;
            distancia = FormulaHaversine(puntoLatitud, puntoLongitud, latitud, longitud);
            placeText.text = "Cancha de futsal sintetica \nPlaza San Luis \n Distancia: " + distancia + " metros";
    	}else //cancha 1 -16.587639, -68.181686
        if(latitud > (-16.587639-0.00020) && latitud < (-16.587639+0.00020) && longitud > (-68.181686-0.00020) && longitud < (-68.181686+0.00020))
        {
            puntoLatitud = -16.587639f;
            puntoLongitud = -68.181686f;
            distancia = FormulaHaversine(puntoLatitud, puntoLongitud, latitud, longitud);
            placeText.text = "Cancha de futsal \nPlaza San Luis \n Distancia: " + distancia + " metros";
        }else // Av. manuela alcala  -16.587198, -68.181701
        if(latitud > (-16.587198-0.00020) && latitud < (-16.587198+0.00020) && longitud > (-68.181701-0.00020) && longitud < (-68.181701+0.00020))
        {
            puntoLatitud = -16.587198f;
            puntoLongitud = -68.181701f;
            distancia = FormulaHaversine(puntoLatitud, puntoLongitud, latitud, longitud);
            placeText.text = "Avenida Manuela de Alcala \n Zona San Luis \n Distancia: " + distancia + " metros";
        }else
        ///borrar       -16.58829 -68.18185
        if(latitud > (-16.58829-0.00020) && latitud < (-16.58829+0.00020) && longitud > (-68.18185-0.00020) && longitud < (-68.18185+0.00020))
        {
            puntoLatitud = -16.58829f;
            puntoLongitud = -68.18185f;
            distancia = FormulaHaversine(puntoLatitud, puntoLongitud, latitud, longitud);
            placeText.text = "Hogar familia Sinka \nZona San Luis \n Distancia: " + distancia + " metros";
    	}else//
        {
            placeText.text = "";
        }
    }
}
