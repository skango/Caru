using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class Slideshow : MonoBehaviour
{
    public List<Slide> Slides = new List<Slide>();
    int CurrentSlide = 0;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            Debug.Log("Forward");
            Slides[CurrentSlide].Forward();
            if (CurrentSlide > Slides.Count)
            {
                Debug.Log("Out of bounds!");
                return;
            }
            CurrentSlide++;
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            Debug.Log("Back");
            Slides[CurrentSlide - 1].Forward();
            if (CurrentSlide == 0)
            {
                Debug.Log("NO MORE SLIDES!");
                return;
            }
            CurrentSlide--;
        }
    }

    public void LoadScene(int Id)
    {
        SceneManager.LoadScene(Id);
    }

    public void GoTo(string Url)
    {
        Application.OpenURL(Url);

    }

    [Serializable]
    public class Slide
    {
        public UnityEvent ForwardEvent, ReverseEvent;

        public void Forward ()
        {
            ForwardEvent.Invoke();
        }

        public void Reverse()
        {
            ReverseEvent.Invoke();
        }
    }
}
