/*
 * Creado por SharpDevelop.
 * Usuario: Rene
 * Fecha: 6/5/2022
 * Hora: 13:58
 * 
 * Para cambiar esta plantilla use Herramientas | Opciones | Codificación | Editar Encabezados Estándar
 */
using System;
using ReneUtiles.Games.VisualNovel.Progresos;
using ReneUtiles.Games.VisualNovel.Partida;
using ReneUtiles.Games.VisualNovel.Personajes;
using ReneUtiles.Games.VisualNovel.Dialogo.Creadores;
namespace ReneUtiles.Games.VisualNovel.Dialogo
{
	/// <summary>
	/// Description of Dialogo_VN.
	/// </summary>
	public class Dialogo_VN
	{
		public Func<ContextoDePartida_VN,ElementoDeDialgo_VN> GetElementoInicial;
		//public ContextoDePartida_VN ContextoDePartida;
		public ContextoDeDialogo_VN ContextoDeDialogo;
		public Dialogo_VN(ContextoDePartida_VN contextoDePartida)
		{
			this.ContextoDeDialogo=new ContextoDeDialogo_VN(contextoDePartida);
		}
		
		
		public void setListaInicial(params CreadorDeElementoDeListaDeDialogo_VN[] lista){
			this.GetElementoInicial=ctx=>{
				ElementoDeListaDeDialogo_VN[] le=new ElementoDeListaDeDialogo_VN[lista.Length];
				for (int i = 0; i < lista.Length; i++) {
					le[i]=lista[i].crearElementoDeListaDeDialogo();
				}
				ListaDeDialogo_VN l=new ListaDeDialogo_VN(this.ContextoDeDialogo.ContextoDePartida.PersonajePrincipal
				                                          ,le);
				return l;
			};
		}
		
		public  ElementoDeDialgo_VN ed(string texto){
			return ed(this.ContextoDeDialogo.ContextoDePartida.PersonajePrincipal,texto);
			
		}
		public  ElementoDeDialgo_VN ed(Personaje_VN personaje,string texto){
			ElementoDeDialgo_VN e=new ElementoDeDialgo_VN(personaje:personaje,texto:texto);
			return e;
		}
		
		
		public SecuenciaDeDialogo_VN sc_ed(string texto){
			SecuenciaDeDialogo_VN sc=new SecuenciaDeDialogo_VN(this);
			return sc.ed(texto);
		}
		public SecuenciaDeDialogo_VN sc_ed(Personaje_VN personaje,string texto){
			SecuenciaDeDialogo_VN sc=new SecuenciaDeDialogo_VN(this);
			return sc.ed(personaje,texto);
		}
		
		
		public SecuenciaDeDialogo_VN sc_eld(string texto){
			SecuenciaDeDialogo_VN sc=new SecuenciaDeDialogo_VN(this);
			return sc.eld(texto);
		}
		public SecuenciaDeDialogo_VN sc_eld(string texto,Etapa_VN reqisitoMinimo){
			SecuenciaDeDialogo_VN sc=new SecuenciaDeDialogo_VN(this);
			return sc.eld(texto,reqisitoMinimo);
		}
		
	}
}
