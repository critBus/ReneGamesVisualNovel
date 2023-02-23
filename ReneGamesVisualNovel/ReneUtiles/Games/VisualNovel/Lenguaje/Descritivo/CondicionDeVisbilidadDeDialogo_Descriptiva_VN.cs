/*
 * Creado por SharpDevelop.
 * Usuario: Rene
 * Fecha: 7/5/2022
 * Hora: 16:32
 * 
 * Para cambiar esta plantilla use Herramientas | Opciones | Codificación | Editar Encabezados Estándar
 */
using System;
using ReneUtiles.Clases.Condicionales;
using ReneUtiles.Games.VisualNovel.Visualizacion.Dialogos; 
namespace ReneUtiles.Games.VisualNovel.Lenguaje.Descritivo
{
	/// <summary>
	/// Description of CondicionDeVisbilidadDeDialogo_Descriptiva_VN.
	/// </summary>
	public class CondicionDeVisbilidadDeDialogo_Descriptiva_VN:CondicionDeVisbilidadDeDialogo_VN
	{
		public Condicional Condicion;
		public CondicionDeVisbilidadDeDialogo_Descriptiva_VN(Condicional condicion)
		{
			this.Condicion=condicion;
		}
	}
}
