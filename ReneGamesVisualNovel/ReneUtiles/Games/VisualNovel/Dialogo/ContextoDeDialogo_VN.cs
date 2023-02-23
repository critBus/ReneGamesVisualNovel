/*
 * Creado por SharpDevelop.
 * Usuario: Rene
 * Fecha: 5/5/2022
 * Hora: 19:37
 * 
 * Para cambiar esta plantilla use Herramientas | Opciones | Codificación | Editar Encabezados Estándar
 */
using System;
using ReneUtiles.Games.VisualNovel.Partida;
namespace ReneUtiles.Games.VisualNovel.Dialogo
{
	/// <summary>
	/// Description of ContextoDeDialogo_VN.
	/// </summary>
	public class ContextoDeDialogo_VN
	{
		public ContextoDePartida_VN ContextoDePartida;
		
		
		public ContextoDeDialogo_VN(ContextoDePartida_VN ctx){//:this()
			this.ContextoDePartida=ctx;
//			this.Progreso=ctx.Progreso;
//			this.PersonajePrincipal=ctx.PersonajePrincipal;
		}
	}
}
