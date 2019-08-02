
namespace GoogleARCore.Examples.AugmentedImage
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.InteropServices;
    using GoogleARCore;
    using GoogleARCoreInternal;
    using UnityEngine;
    using System.Collections;
    //canvas ve tuþ(button) kullanabilmemiz için ui kütüphanesini belirtiyoruz.
    using UnityEngine.UI;
    //sahne geçiþi için gerekli kütüphaneyi belirtiyoruz
    using UnityEngine.SceneManagement;
    
    
    public class AugmentedImageVisualizer : MonoBehaviour
    {//objelerimizi kodun içinde kullanabilmek için gerekli kodlar

        public GameObject oyuncu;
        public GameObject ok6;
        public GameObject ok7;
        public GameObject ok8;
        public GameObject ok9;
        public GameObject ok1;
        public GameObject ok2;
        public GameObject ok3;
        public GameObject ok4;
        public GameObject ok5;
        public GameObject okbase;
        //hedef resim, kod çinde kullanabilmek için gerekli kod
        public AugmentedImage Image;
        //tuþlar için gerekli kodlar
        public Button dek;
        public Button ibf;
        public Button ogr;
        public Button res; 

        //objelerimiziin görünür olabileceði en fazla mesafe
        private float maxDistance = 1.500f;
        //objenin üzerine geldiðimizde renk deðiþtirmesini saðlamak için gerekli kodlar
        //objeye yakýnlýk kodu
        private float tran1 = 0.500f;
        //saydamlýk renk kodu(yarý saydam)
        Color myColortran = new Color32(22, 144, 47, 130);
        //saydamlýk renk kodu(tam görünür)
        Color myColor = new Color32(22, 144, 47, 255);
        
        //butonlara basýldýðýnda deðiþen deðiþkenler
        private int buttondekbas = 0;
        private int buttoniibfbas = 0;
        private int buttonogrbas = 0;
        private int buttonresbas = 0;
        //tekrar baþlatma butonu basýldýðýnda aktifleþecek kod
        public void butonres()
        {//sahneyi yeniden yükleyerek yeniden baþlatma
            //deneme1 yerine sizin belirlediðiniz sahne adý
            SceneManager.LoadScene("deneme1");

        }
        //dekanlýk butonuna basýldýðý zaman yapýlacaklar
        public void butondek()
        {
            //dekanlýk ve yeniden baþlatma deðiþkenlerini deðiþtirir
            buttonogrbas = 0;
            buttoniibfbas = 0;
            buttondekbas = 1;
            buttonresbas = 1;
            
        }
        //iibf butonuna  basýldýðý zaman yapýlacaklar
        public void butonibf()
        {
            //deðiþkenler deðiþtirir
            buttonogrbas = 0;
            buttoniibfbas = 1;
            buttondekbas = 0;
            buttonresbas = 1;

        }//öðrenci iþleri butonuna basýldýðýnda yapýlacaklar
        public void butonogr()
        {//deðiþkenleri deðiþtirir
            buttonogrbas = 1;
            buttoniibfbas = 0;
            buttondekbas = 0;
            buttonresbas = 1;

        }
        //güncelleme kod bloðu
        public void Update()
        {//eðer öðrenci iþleri butonunun deðeri 1 ise(basýldýysa)
            if (buttonresbas == 1)
            {//yeniden baþlatma butonu aktif
                res.gameObject.SetActive(true);
            }
            //küre(sphere) nesnesinin konumunu kamera konumuna eþitleme. Oyuncunun konumu yerine geçecek
            oyuncu.transform.position = Camera.current.transform.position;
            //eðer veri tabanýndaki herhangi bir resim okunmuyorsa
            if (Image == null || Image.TrackingState != TrackingState.Tracking)
            {//herþeyi görünmez yap
                ok6.SetActive(false);
                ok7.SetActive(false);
                ok8.SetActive(false);
                ok9.SetActive(false);
                ok1.SetActive(false);
                ok2.SetActive(false);
                ok3.SetActive(false);
                ok4.SetActive(false);
                ok5.SetActive(false);
                okbase.SetActive(false);
                ogr.gameObject.SetActive(false);
                ibf.gameObject.SetActive(false);
                dek.gameObject.SetActive(false);
                res.gameObject.SetActive(false);
                return;
            }
            else
            {//veri tabanýndaki bir resim okunduysa tuþlarý aktiflerþtir
                ogr.gameObject.SetActive(true);
                ibf.gameObject.SetActive(true);
                dek.gameObject.SetActive(true);
            }
            //dekanlýk butonu basýldýysa
            if (buttondekbas==1)
            {//yeniden baþlat butonu haricindeki butonlarý gizle
                ogr.gameObject.SetActive(false);
                ibf.gameObject.SetActive(false);
                dek.gameObject.SetActive(false);
                res.gameObject.SetActive(true);
                //oyuncunun uzaklýðý  ok6 nesnesinden maxDistance deðiþkeninde belirtilen mesafeden daha az ise
                if (Vector3.Distance(oyuncu.transform.position, ok6.transform.position) < maxDistance)
                {//ok6 nesnesini aktifleþtir
                    ok6.SetActive(true);
                    //ok6 nesnesini belirtilen pozisyona koy
                    ok6.transform.position = new Vector3(0f, 0.050f, 0.500f);
                    //ok6 nesnesini x ekseninde 90 derece döndür
                    ok6.transform.rotation = Quaternion.Euler(90f, 0f, 0f);


                }//deðilse
                else
                {//ok6 nesnesini görünmez yap
                    ok6.SetActive(false);
                }
                //eðer ok6 nesnesi ile oyuncu arasýndaki uzaklýk tran1 deðiþkeninde verilen deðerden düþükse(oyuncu ok6 ya deðiyorsa)
                if (Vector3.Distance(oyuncu.transform.position, ok6.transform.position) < tran1)
                {//ok6 nýn rengini myColor deðiþkeninde belirtilen renk ve saydamlýða getir
                    ok6.GetComponent<Renderer>().material.color = myColor; }
                else//deðilse
                {//ok6 nýn rengini myColortran deðiþkeninde belirtilen renk ve saydamlýða getir
                    ok6.GetComponent<Renderer>().material.color = myColortran; }
                if (Vector3.Distance(oyuncu.transform.position, ok7.transform.position) < maxDistance)
                {
                    ok7.SetActive(true);
                    ok7.transform.position = new Vector3(0f, 0.050f, 1f);
                    ok7.transform.rotation = Quaternion.Euler(90f, 0f, 0f);

                }
                else
                {
                    ok7.SetActive(false);
                }
                if (Vector3.Distance(oyuncu.transform.position, ok7.transform.position) < tran1)
                { ok7.GetComponent<Renderer>().material.color = myColor; }
                else
                { ok7.GetComponent<Renderer>().material.color = myColortran; }
                if (Vector3.Distance(oyuncu.transform.position, ok8.transform.position) < maxDistance)
                {
                    ok8.SetActive(true);
                    ok8.transform.position = new Vector3(0f, 0.050f, 1.500f);
                    ok8.transform.rotation = Quaternion.Euler(90f, 0f, 0f);
                }
                else
                {
                    ok8.SetActive(false);
                }
                if (Vector3.Distance(oyuncu.transform.position, ok8.transform.position) < tran1)
                { ok8.GetComponent<Renderer>().material.color = myColor; }
                else
                { ok8.GetComponent<Renderer>().material.color = myColortran; }
                if (Vector3.Distance(oyuncu.transform.position, ok9.transform.position) < maxDistance)
                {
                    ok9.SetActive(true);
                    ok9.transform.position = new Vector3(0f, 0.050f, 2f);
                    ok9.transform.rotation = Quaternion.Euler(90f, 0f, 0f);

                }
                else
                {
                    ok9.SetActive(false);
                }
                if (Vector3.Distance(oyuncu.transform.position, ok9.transform.position) < tran1)
                { ok9.GetComponent<Renderer>().material.color = myColor; }
                else
                { ok9.GetComponent<Renderer>().material.color = myColortran; }
                if (Vector3.Distance(oyuncu.transform.position, ok1.transform.position) < maxDistance)
                {
                    ok1.SetActive(true);
                    ok1.transform.position = new Vector3(0f, 0.050f, 2.500f);
                    ok1.transform.rotation = Quaternion.Euler(90f, 0f, 0f);

                }
                else
                {
                    ok1.SetActive(false);
                }
                if (Vector3.Distance(oyuncu.transform.position, ok1.transform.position) < tran1)
                { ok1.GetComponent<Renderer>().material.color = myColor; }
                else
                { ok1.GetComponent<Renderer>().material.color = myColortran; }
                if (Vector3.Distance(oyuncu.transform.position, ok2.transform.position) < maxDistance)
                {
                    ok2.SetActive(true);
                    ok2.transform.position = new Vector3(0f, 0.050f, 3f);
                    ok2.transform.rotation = Quaternion.Euler(90f, 0f, 0f);

                }
                else
                {
                    ok2.SetActive(false);
                }
                if (Vector3.Distance(oyuncu.transform.position, ok2.transform.position) < tran1)
                { ok2.GetComponent<Renderer>().material.color = myColor; }
                else
                { ok2.GetComponent<Renderer>().material.color = myColortran; }
                if (Vector3.Distance(oyuncu.transform.position, ok3.transform.position) < maxDistance)
                {
                    ok3.SetActive(true);
                    ok3.transform.position = new Vector3(0f, 0.050f, 3.500f);
                    ok3.transform.rotation = Quaternion.Euler(90f, 0f, 0f);

                }
                else
                {
                    ok3.SetActive(false);
                }
                if (Vector3.Distance(oyuncu.transform.position, ok3.transform.position) < tran1)
                { ok3.GetComponent<Renderer>().material.color = myColor; }
                else
                { ok3.GetComponent<Renderer>().material.color = myColortran; }
                if (Vector3.Distance(oyuncu.transform.position, ok4.transform.position) < maxDistance)
                {
                    ok4.SetActive(true);
                    ok4.transform.position = new Vector3(0f, 0.050f, 4f);
                    ok4.transform.rotation = Quaternion.Euler(90f, 0f, 0f);

                }
                else
                {
                    ok4.SetActive(false);
                }
                if (Vector3.Distance(oyuncu.transform.position, ok4.transform.position) < tran1)
                { ok4.GetComponent<Renderer>().material.color = myColor; }
                else
                { ok4.GetComponent<Renderer>().material.color = myColortran; }
                if (Vector3.Distance(oyuncu.transform.position, ok5.transform.position) < maxDistance)
                {
                    ok5.SetActive(true);
                    ok5.transform.position = new Vector3(0f, 0.050f, 4.500f);
                    ok5.transform.rotation = Quaternion.Euler(0f, 0f, 0f);

                }
                else
                {
                    ok5.SetActive(false);
                }
                //varýþ noktasýný belirten nesnenin rengini deðiþtirmedim.Her zaman ayný renkte görünecek
                if (Vector3.Distance(oyuncu.transform.position, okbase.transform.position) < maxDistance)
                {
                    okbase.SetActive(true);
                    okbase.transform.position = new Vector3(0f, 0.050f, 0f);
                    okbase.transform.rotation = Quaternion.Euler(90f, 0f, 0f);

                }
                else
                {
                    okbase.SetActive(false);
                }
                if (Vector3.Distance(oyuncu.transform.position, okbase.transform.position) < tran1)
                { okbase.GetComponent<Renderer>().material.color = myColor; }
                else
                { okbase.GetComponent<Renderer>().material.color = myColortran; }
            }
            //ayný kod bloklarý diðer nesneler(oklar) için tekrarlanýr 
            //isimlerin deðiþtirilmesine dikkat edilmelidir.
            


            

        }
    }
}
