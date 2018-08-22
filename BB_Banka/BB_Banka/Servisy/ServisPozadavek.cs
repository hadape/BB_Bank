using BB_Banka.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BB_Banka
{
    public class ServisPozadavek



    {
        private KalkulaceEntities context;

        public ServisPozadavek() //konstruktor, naplní kontext
        {
            context = new KalkulaceEntities(); //celá struktura databáze
        }

        public List<POZADAVKY> GetPozadavky()
        {
            return context.POZADAVKY.ToList();
        }

        //public Student GetStudent(int id)
        //{
        //    return context.Students.First(s => s.Id == id);
        //}

        //public void DeleteStudent(int id)
        //{

        //    context.Students.Remove(context.Students.First(s => s.Id == id));
        //    context.SaveChanges();
        //}

        //public Student AddStudent(Student student)
        //{
        //    context.Students.Add(student);
        //    context.SaveChanges();
        //    return student;

        //}

    }




}