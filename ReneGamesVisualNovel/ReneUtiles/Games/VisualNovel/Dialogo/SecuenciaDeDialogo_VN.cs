/*
 * Creado por SharpDevelop.
 * Usuario: Rene
 * Fecha: 6/5/2022
 * Hora: 19:21
 * 
 * Para cambiar esta plantilla use Herramientas | Opciones | Codificación | Editar Encabezados Estándar
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ReneUtiles.Games.VisualNovel.Partida;
using ReneUtiles.Games.VisualNovel.Personajes;
using ReneUtiles.Games.VisualNovel.Progresos;
using ReneUtiles.Games.VisualNovel.Visualizacion;
using ReneUtiles.Games.VisualNovel.Visualizacion.Creadores;
using ReneUtiles.Games.VisualNovel.Dialogo.Creadores;
using ReneUtiles.Games.VisualNovel.Ubicaciones;

using ReneUtiles.Games.VisualNovel.Lenguaje.Descritivo;
using ReneUtiles.Games.VisualNovel.Lenguaje.Ejecutable;

using ReneUtiles.Clases.LeguajeDescritivo.Metodos;



namespace ReneUtiles.Games.VisualNovel.Dialogo
{
	/// <summary>
	/// Description of SecuenciaDeDialogo_VN.
	/// </summary>
	public class SecuenciaDeDialogo_VN:CreadorDeElementoDeDialogo_VN,CreadorDeElementoDeListaDeDialogo_VN,CreadorDeEscenario_VN 
	{
		private List<Func<Escenario_VN,ElementoDeDialgo_VN>> listaDeCreadores;
		private Func<Escenario_VN,ElementoDeListaDeDialogo_VN> creadorElementoDeListaDeDialogo;
		private Ubicacion_VN ubicacionFinal;
//
		public Dialogo_VN Dialogo;
		private bool usarLenguajeDescriptivo = true;
		//private int indiceActual;
		
		public SecuenciaDeDialogo_VN(Dialogo_VN dialogo)
		{
			this.listaDeCreadores = new List<Func<Escenario_VN,ElementoDeDialgo_VN>>();
			this.Dialogo = dialogo;
			//indiceActual=-1;
		}
		
		
		
		public SecuenciaDeDialogo_VN ed(string texto,Ubicacion_VN end=null)
		{
			this.ubicacionFinal=end;
			listaDeCreadores.Add(es => {
				ElementoDeDialgo_VN e = Dialogo.ed(texto);
				ponerTransicion(e,es);
//				if (es != null) {
//					e.TrasicionASiguienteElemento = ctx => es;
//				}
				
			                     	
				return e;
			});
			return this;
		}
		public SecuenciaDeDialogo_VN ed(Personaje_VN personaje, string texto,Ubicacion_VN end=null)
		{
			this.ubicacionFinal=end;
			listaDeCreadores.Add(es => {
				ElementoDeDialgo_VN e = Dialogo.ed(personaje, texto);
				ponerTransicion(e,es);
//				if (es != null) {
//					e.TrasicionASiguienteElemento = ctx => es;
//				}
				return e;
			});
			return this;
		}
		
		public  SecuenciaDeDialogo_VN eld(string texto)
		{
			creadorElementoDeListaDeDialogo = es => {
				ElementoDeListaDeDialogo_VN e = new ElementoDeListaDeDialogo_VN(texto);
				ponerTransicion(e,es);
				return e;
//				if (es != null) {
//					e.TrasicionASiguienteElemento = ctx => es;
//				}
			};
			
			
			//e.TrasicionASiguienteElemento=new TransicionDeDialogo_VN(ctx=>siguiente);
			return this;
		}
		
		public  SecuenciaDeDialogo_VN eld(string texto,Etapa_VN reqisitoMinimo)
		{
			creadorElementoDeListaDeDialogo = es => {
				ElementoDeListaDeDialogo_VN e = new ElementoDeListaDeDialogo_VN(texto);
				ponerTransicion(e,es);
				if(usarLenguajeDescriptivo){
					e.Condicion=new CondicionDeVisbilidadDeOpcion_Descriptiva_VN(reqisitoMinimo);
				}else{
					e.Condicion=new CondicionDeVisbilidadDeOpcion_Ejecutable_VN(ctx=>ctx.ContextoDePartida.seHaProgresadoHasta(reqisitoMinimo));
				}
				
				return e;
//				if (es != null) {
//					e.TrasicionASiguienteElemento = ctx => es;
//				}
			};
			
			
			//e.TrasicionASiguienteElemento=new TransicionDeDialogo_VN(ctx=>siguiente);
			return this;
		}
		
		private void ponerTransicion(dynamic e,Escenario_VN es)
		{
			if (es != null) {
				e.TrasicionASiguienteElemento = new TransicionDeDialogo_VN( ctx => es);
			}
		}
		
		public SecuenciaDeDialogo_VN end(params Etapa_VN[] etapasACompletar){
			
			if(creadorElementoDeListaDeDialogo!=null&&listaDeCreadores.Count==0){
				creadorElementoDeListaDeDialogo=es=>creadorElementoDeListaDeDialogo(es).end(etapasACompletar);
				return this;
			}
			
			int indice=listaDeCreadores.Count-1;
			Func<Escenario_VN,ElementoDeDialgo_VN> creador=listaDeCreadores[indice];
			listaDeCreadores[indice]=es=>creador(es).end(etapasACompletar);
			return this;
		}
		
		public  Escenario_VN crearEscenario(){
			return crearElementoDeDialogo();
		}
		public  ElementoDeListaDeDialogo_VN crearElementoDeListaDeDialogo(){
			return creadorElementoDeListaDeDialogo(crearElementoDeDialogo());
		}
		public  ElementoDeDialgo_VN crearElementoDeDialogo()
		{
			List<ElementoDeDialgo_VN> le = new List<ElementoDeDialgo_VN>();
			ElementoDeDialgo_VN anterior = null;
			for (int i = le.Count - 1; i >= 0; i--) {
				ElementoDeDialgo_VN actual = listaDeCreadores[i](anterior);//(i!=le.Count-1?le[i-1]:null)
				le.Add(actual);
				anterior = actual;
			}
			ponerTransicion(anterior,this.ubicacionFinal); 
			return anterior;
//			foreach(Func<Escenario_VN,ElementoDeDialgo_VN> f in listaDeCreadores){
//				
//			}
		}
	}
}
