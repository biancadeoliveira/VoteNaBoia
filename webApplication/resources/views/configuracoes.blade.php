@extends('templates.app')
@extends('templates.menu')

@section('conteudo')
<div class="container">
    <h1 class="votacaosemanal">Configurações</h1>
    <div class="row align-items-center">
        <div class="col">
            <img class="rounded float-left" src="assets/image/profile_pic_img.png" style="margin-top: 7%;">
        </div>
        <div class="col">
            <h1 style="color: #323232">Otávio</h1>
            <h5 style="color: #323232">MODERADOR</h5>
        </div>
        <div class="col">
            <i class="fas fa-sign-out-alt otavio"></i>
        </div>
    </div>
    <div class="row">
        <div class="col">
            <button type="button" class="btn btn-primary btn-lg btn-block editprofile otavio"><i class="fas fa-user-edit"></i>  Editar Perfil</button>
        </div>
    </div>
    <div class="row">
        <div class="col">
            <button type="button" class="btn btn-primary btn-lg btn-block editprofile otavio"><i class="fas fa-bell"></i>  Gerenciar Notificações</button>
        </div>
    </div>
    <div class="row">
        <div class="col">
            <button type="button" class="btn btn-primary btn-lg btn-block moderator otavio"><i class="fas fa-user-shield"></i>  Controles de Moderação</button>
        </div>
    </div>
</div>


@endsection
