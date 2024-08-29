using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Guna.UI2.Native.WinApi;

namespace SistemaKinesiologia.Clases
{
    public class Evaluacion
    {
        // Atributos
        internal int IdEvaluacion {  get; set; }
        internal string nombre {  get; set; }
        internal string observaciones { get; set; }
        internal DateTime fecha {  get; set; }

        // Tabla 1:
        internal string nombreTabla1 { get; set; }
        internal List<string> fila1Tabla1 {  get; set; }
        internal List<string> fila2Tabla1 { get; set; }
        internal List<string> fila3Tabla1 { get; set; }
        internal List<string> fila4Tabla1 { get; set; }
        internal List<string> fila5Tabla1 { get; set; }

        // Tabla 2:
        internal string nombreTabla2 { get; set; }
        internal List<string> fila1Tabla2 { get; set; }
        internal List<string> fila2Tabla2 { get; set; }
        internal List<string> fila3Tabla2 { get; set; }
        internal List<string> fila4Tabla2 { get; set; }
        internal List<string> fila5Tabla2 { get; set; }

        // Para BD
        internal int IdKinesiologo {  get; set; }
        internal Kinesiologo kinesiologo {  get; set; }

        internal int IdLesion {  get; set; }
        internal Lesion lesion {  get; set; }

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
        internal string GetObservacionesEvaluacion() { return this.observaciones; }

        internal void SetNombre(string nombre) {  this.nombre = nombre; }
        internal void SetFecha(DateTime fecha) { this.fecha = fecha;}
        internal void SetObservaciones(string observaciones) { this.observaciones = observaciones; }
        internal void SetNombreTabla1(string nombreTabla1) { this.nombreTabla1 =  nombreTabla1; }
        internal void SetNombreTabla2(string nombreTabla2) { this.nombreTabla2 = nombreTabla2; }
        internal void SetFila1Tabla1(List<string> lista) { this.fila1Tabla1 = lista; }
        internal void SetFila2Tabla1(List<string> lista) { this.fila2Tabla1 = lista; }
        internal void SetFila3Tabla1(List<string> lista) { this.fila3Tabla1 = lista; }
        internal void SetFila4Tabla1(List<string> lista) { this.fila4Tabla1 = lista; }
        internal void SetFila5Tabla1(List<string> lista) { this.fila5Tabla1 = lista; }

        internal void SetFila1Tabla2(List<string> lista) { this.fila1Tabla2 = lista; }
        internal void SetFila2Tabla2(List<string> lista) { this.fila2Tabla2 = lista; }
        internal void SetFila3Tabla2(List<string> lista) { this.fila3Tabla2 = lista; }
        internal void SetFila4Tabla2(List<string> lista) { this.fila4Tabla2 = lista; }
        internal void SetFila5Tabla2(List<string> lista) { this.fila5Tabla2 = lista; }

        internal void AsignarKine(Kinesiologo kine) { this.kinesiologo =  kine; }
        internal void AsignarLesion(Lesion lesion) { this.lesion = lesion; }

        internal string GetNombreTabla1() { return this.nombreTabla1; }
        internal string GetNombreTabla2() { return this.nombreTabla2; }
        internal List<string> GetFila1Tabla1() { return this.fila1Tabla1; }
        internal List<string> GetFila2Tabla1() { return this.fila2Tabla1; }
        internal List<string> GetFila3Tabla1() { return this.fila3Tabla1; }
        internal List<string> GetFila4Tabla1() { return this.fila4Tabla1; }
        internal List<string> GetFila5Tabla1() { return this.fila5Tabla1; }

        internal List<string> GetFila1Tabla2() { return this.fila1Tabla2; }
        internal List<string> GetFila2Tabla2() { return this.fila2Tabla2; }
        internal List<string> GetFila3Tabla2() { return this.fila3Tabla2; }
        internal List<string> GetFila4Tabla2() { return this.fila4Tabla2; }
        internal List<string> GetFila5Tabla2() { return this.fila5Tabla2; }
    }
}
