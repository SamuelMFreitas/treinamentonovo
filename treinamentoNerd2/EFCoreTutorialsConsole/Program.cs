using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Runtime.CompilerServices;

namespace EFCoreTutorialsConsole
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CriarEntidades();

            LisrtarEstadoEntidades();
            ListarEstadoAddedEntidade();
            ListarEstadoModificado();

            ListarEstadoDeletedEntidades();
            ListarEstadoDetachedEntidade();

        }

        private static void ListarEstadoDetachedEntidade()
        {
            var disconnectedEntity = new Student() { StudentId = 1, FirstName = "Bill" };

            using (var context = new SchoolContext())
            {
                Console.Write(context.Entry(disconnectedEntity).State);
            }
        }

        private static void ListarEstadoDeletedEntidades()
        {
            using (var context = new SchoolContext())
            {
                var student = context.Students.FirstOrDefault();
                context.Students.Remove(student);

                DisplayStates(context.ChangeTracker.Entries());
            }
        }

        private static void ListarEstadoModificado()
        {
            using (var context = new SchoolContext())
            {
                var student = context.Students.FirstOrDefault();
                student.LastName = "Friss";

                DisplayStates(context.ChangeTracker.Entries());
            }
        }

        private static void ListarEstadoAddedEntidade()
        {
            using (var context = new SchoolContext())
            {
                context.Students.Add(new Student() { FirstName = "Bill", LastName = "Gates" });

                DisplayStates(context.ChangeTracker.Entries());
            }
        }

        private static void LisrtarEstadoEntidades()
        {
            using (var context = new SchoolContext())
            {
                // retrieve entity 
                var student = context.Students.FirstOrDefault();
                DisplayStates(context.ChangeTracker.Entries());
            }
        }

        static void DisplayStates(IEnumerable<EntityEntry> entries)
        {
            foreach (var entry in entries)
            {
                Console.WriteLine($"Entidade: {entry.Entity.GetType().Name}, " +
                    $"State: {entry.State.ToString()}");
            }

         }

            private static void CriarEntidades()
        {
            using (SchoolContext context = new SchoolContext())
            {
                //Criar BD
                context.Database.EnsureCreated();

                //Criar uma entidade de objeto
                var grade01 = new Grade() { GradeName = "Curso c# .Net" };
                var student01 = new Student() { FirstName = "Pinóquio", LastName = "Silveirinha", Grade = grade01 };

                //Adicionar a entidade ao contexto
                context.Students.Add(student01);

                //Salvar a entidade estudante
                context.SaveChanges();

                foreach (var std in context.Students)
                {
                    Console.WriteLine(std.FirstName + " " + std.LastName);
                }
            }
        }
    }
}