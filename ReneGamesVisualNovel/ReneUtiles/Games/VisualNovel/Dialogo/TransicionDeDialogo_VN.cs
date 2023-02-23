/*
 * Creado por SharpDevelop.
 * Usuario: Rene
 * Fecha: 6/5/2022
 * Hora: 12:42
 * 
 * Para cambiar esta plantilla use Herramientas | Opciones | Codificación | Editar Encabezados Estándar
 */
using System;
using ReneUtiles.Games.VisualNovel.Visualizacion;
namespace ReneUtiles.Games.VisualNovel.Dialogo
{
	/// <summary>
	/// Description of TransicionDeDialogo_VN.
	/// </summary>
	public class TransicionDeDialogo_VN
	{
		public Func<ContextoDeDialogo_VN,Escenario_VN> GetElementoSiguiente;
		public TransicionDeDialogo_VN(Func<ContextoDeDialogo_VN,Escenario_VN> getElementoSiguiente)
		{
			this.GetElementoSiguiente=getElementoSiguiente;   
		}
	}
}
