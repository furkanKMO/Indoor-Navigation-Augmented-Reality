
namespace GoogleARCore.Examples.AugmentedImage
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.InteropServices;
    using GoogleARCore;
    using GoogleARCoreInternal;
    using UnityEngine;
    using System.Collections;
    //canvas ve tu�(button) kullanabilmemiz i�in ui k�t�phanesini belirtiyoruz.
    using UnityEngine.UI;
    //sahne ge�i�i i�in gerekli k�t�phaneyi belirtiyoruz
    using UnityEngine.SceneManagement;
    
    
    public class AugmentedImageVisualizer : MonoBehaviour
    {//objelerimizi kodun i�inde kullanabilmek i�in gerekli kodlar

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
        //hedef resim, kod �inde kullanabilmek i�in gerekli kod
        public AugmentedImage Image;
        //tu�lar i�in gerekli kodlar
        public Button dek;
        public Button ibf;
        public Button ogr;
        public Button res; 

        //objelerimiziin g�r�n�r olabilece�i en fazla mesafe
        private float maxDistance = 1.500f;
        //objenin �zerine geldi�imizde renk de�i�tirmesini sa�lamak i�in gerekli kodlar
        //objeye yak�nl�k kodu
        private float tran1 = 0.500f;
        //saydaml�k renk kodu(yar� saydam)
        Color myColortran = new Color32(22, 144, 47, 130);
        //saydaml�k renk kodu(tam g�r�n�r)
        Color myColor = new Color32(22, 144, 47, 255);
        
        //butonlara bas�ld���nda de�i�en de�i�kenler
        private int buttondekbas = 0;
        private int buttoniibfbas = 0;
        private int buttonogrbas = 0;
        private int buttonresbas = 0;
        //tekrar ba�latma butonu bas�ld���nda aktifle�ecek kod
        public void butonres()
        {//sahneyi yeniden y�kleyerek yeniden ba�latma
            //deneme1 yerine sizin belirledi�iniz sahne ad�
            SceneManager.LoadScene("deneme1");

        }
        //dekanl�k butonuna bas�ld��� zaman yap�lacaklar
        public void butondek()
        {
            //dekanl�k ve yeniden ba�latma de�i�kenlerini de�i�tirir
            buttonogrbas = 0;
            buttoniibfbas = 0;
            buttondekbas = 1;
            buttonresbas = 1;
            
        }
        //iibf butonuna  bas�ld��� zaman yap�lacaklar
        public void butonibf()
        {
            //de�i�kenler de�i�tirir
            buttonogrbas = 0;
            buttoniibfbas = 1;
            buttondekbas = 0;
            buttonresbas = 1;

        }//��renci i�leri butonuna bas�ld���nda yap�lacaklar
        public void butonogr()
        {//de�i�kenleri de�i�tirir
            buttonogrbas = 1;
            buttoniibfbas = 0;
            buttondekbas = 0;
            buttonresbas = 1;

        }
        //g�ncelleme kod blo�u
        public void Update()
        {//e�er ��renci i�leri butonunun de�eri 1 ise(bas�ld�ysa)
            if (buttonresbas == 1)
            {//yeniden ba�latma butonu aktif
                res.gameObject.SetActive(true);
            }
            //k�re(sphere) nesnesinin konumunu kamera konumuna e�itleme. Oyuncunun konumu yerine ge�ecek
            oyuncu.transform.position = Camera.current.transform.position;
            //e�er veri taban�ndaki herhangi bir resim okunmuyorsa
            if (Image == null || Image.TrackingState != TrackingState.Tracking)
            {//her�eyi g�r�nmez yap
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
            {//veri taban�ndaki bir resim okunduysa tu�lar� aktifler�tir
                ogr.gameObject.SetActive(true);
                ibf.gameObject.SetActive(true);
                dek.gameObject.SetActive(true);
            }
            //dekanl�k butonu bas�ld�ysa
            if (buttondekbas==1)
            {//yeniden ba�lat butonu haricindeki butonlar� gizle
                ogr.gameObject.SetActive(false);
                ibf.gameObject.SetActive(false);
                dek.gameObject.SetActive(false);
                res.gameObject.SetActive(true);
                //oyuncunun uzakl���  ok6 nesnesinden maxDistance de�i�keninde belirtilen mesafeden daha az ise
                if (Vector3.Distance(oyuncu.transform.position, ok6.transform.position) < maxDistance)
                {//ok6 nesnesini aktifle�tir
                    ok6.SetActive(true);
                    //ok6 nesnesini belirtilen pozisyona koy
                    ok6.transform.position = new Vector3(0f, 0.050f, 0.500f);
                    //ok6 nesnesini x ekseninde 90 derece d�nd�r
                    ok6.transform.rotation = Quaternion.Euler(90f, 0f, 0f);


                }//de�ilse
                else
                {//ok6 nesnesini g�r�nmez yap
                    ok6.SetActive(false);
                }
                //e�er ok6 nesnesi ile oyuncu aras�ndaki uzakl�k tran1 de�i�keninde verilen de�erden d���kse(oyuncu ok6 ya de�iyorsa)
                if (Vector3.Distance(oyuncu.transform.position, ok6.transform.position) < tran1)
                {//ok6 n�n rengini myColor de�i�keninde belirtilen renk ve saydaml��a getir
                    ok6.GetComponent<Renderer>().material.color = myColor; }
                else//de�ilse
                {//ok6 n�n rengini myColortran de�i�keninde belirtilen renk ve saydaml��a getir
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
                //var�� noktas�n� belirten nesnenin rengini de�i�tirmedim.Her zaman ayn� renkte g�r�necek
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
            //ayn� kod bloklar� di�er nesneler(oklar) i�in tekrarlan�r 
            //isimlerin de�i�tirilmesine dikkat edilmelidir.
            


            

        }
    }
}
