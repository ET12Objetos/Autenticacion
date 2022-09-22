using Dominio.Entidades;

namespace Tests;

public class UsuarioTests
{
    [Fact]
    public void Habilitar_CuandoUsuarioSeCrea_DebeRetornarFalso()
    {
        var usuario = new Usuario("nombreUsuario", "1234");

        var resultado = usuario.Habilitado;

        Assert.False(resultado);
    }

    [Fact]
    public void Habilitar_CuandoUsuarioSeHabilitaNuevamenteDespuesDeCreado_DebeRetornarExcepcion()
    {
        var usuario = new Usuario("nombreUsuario", "1234");

        usuario.Habilitar();

        Assert.Throws<Exception>(() => usuario.Habilitar());
    }

    [Fact]
    public void Habilitar_CuandoUsuarioSeHabilitDespuesDeCreado_DebeRetornarVerdadero()
    {
        var usuario = new Usuario("nombreUsuario", "1234");

        usuario.Habilitar();

        var resultado = usuario.Habilitado;

        Assert.True(resultado);
    }

    [Fact]
    public void Deshabilitar_CuandoUsuarioSeDeshabilitaDespuesDeCreado_DebeRetornarExcepcion()
    {
        var usuario = new Usuario("nombreUsuario", "1234");

        Assert.Throws<Exception>(() => usuario.Deshabilitar());
    }

    [Fact]
    public void Actualizar_CuandoSeActualizaUnUsuario_DebeRetornarVerdadero()
    {
        // Given
        var usuario = new Usuario("nombreUsuario", "1234");

        var usuarioConCambios = new Usuario("nuevoUsuario", "god");

        // When
        usuario.Actualizar(usuarioConCambios);

        // Then
        Assert.Equal(usuario.Nombre, usuarioConCambios.Nombre);
        Assert.Equal(usuario.Contraseña, usuarioConCambios.Contraseña);
    }
}