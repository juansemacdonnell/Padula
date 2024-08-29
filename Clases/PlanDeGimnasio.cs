using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Guna.UI2.Native.WinApi;

namespace SistemaKinesiologia.Clases
{
    public class PlanDeGimnasio
    {
        // Atributos
        internal int IdPlanGimnasio {  get; set; }
        internal string nombre {  get; set; }
        internal DateTime fecha {  get; set; }

        // Tabla
        internal string tituloColumna1 { get; set; }
        internal string tituloColumna2 { get; set; }
        internal string tituloColumna3 { get; set; }
        internal List<string> fila1 { get; set; }
        internal List<string> fila2 { get; set; }
        internal List<string> fila3 { get; set; }
        internal List<string> fila4 { get; set; }
        internal List<string> fila5 { get; set; }

        // Para BD
        internal int? IdPaciente { get; set; }
        internal Paciente paciente { get; set; }

        internal int? IdLesion { get; set; }
        internal Lesion lesion { get; set; }

        internal int IdKinesiologo { get; set; }
        internal Kinesiologo kinesiologo { get; set; }

        // Constructores

        // Metodos
        internal string GetNombre()
        {
            return this.nombre;
        }

        internal DateTime GetFecha()
        {
            return this.fecha;
        }
        // internal void AsignarPaciente(Paciente paciente) { this.paciente = paciente; }
        internal void AsignarLesion(Lesion lesion) { this.lesion = lesion; }
        internal void AsignarKine(Kinesiologo kinesiologo) { this.kinesiologo = kinesiologo; }

        internal void SetNombre(string nombre) {  this.nombre = nombre; }
        internal void SetTituloColumna1(string nombre) { this.tituloColumna1 = nombre; }
        internal void SetTituloColumna2(string nombre) { this.tituloColumna2 = nombre; }
        internal void SetTituloColumna3(string nombre) { this.tituloColumna3 = nombre; }
        internal void SetFecha(DateTime fecha) { this.fecha = fecha; }
        internal void SetFila1(List<string> lista) { this.fila1 = lista; }
        internal void SetFila2(List<string> lista) { this.fila2 = lista; }
        internal void SetFila3(List<string> lista) { this.fila3 = lista; }
        internal void SetFila4(List<string> lista) { this.fila4 = lista; }
        internal void SetFila5(List<string> lista) { this.fila5 = lista; }

        internal List<string> GetFila1() { return this.fila1; }
        internal List<string> GetFila2() { return this.fila2; }
        internal List<string> GetFila3() { return this.fila3; }
        internal List<string> GetFila4() { return this.fila4; }
        internal List<string> GetFila5() { return this.fila5; }
        internal string GetTituloColumna1() { return this.tituloColumna1;}
        internal string GetTituloColumna2() { return this.tituloColumna2; }
        internal string GetTituloColumna3() { return this.tituloColumna3; }

    }
}
