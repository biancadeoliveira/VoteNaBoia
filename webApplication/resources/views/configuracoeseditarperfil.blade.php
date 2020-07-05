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
    </div>
    <form>
        <div class="form-group">
            <label for="Nome">Nome</label>
            <input class="form-control" type="text" placeholder="">
        </div>
        <div class="form-group">
            <label for="Email">Email</label>
            <input type="email" class="form-control" id="Email" aria-describedby="emailHelp" placeholder="">
        </div>
        <div class="form-group">
            <label for="Senha">Senha</label>
            <input type="password" class="form-control" id="senha" placeholder="">
        </div>
        <div class="form-group">
            <label for="ConfirmaSenha">Confirme sua senha</label>
            <input type="password" class="form-control" id="confirmaSenha" placeholder="">
        </div>
    </form>
    <div class="row align-items-center">
        <div class="col">
            <button type="button" class="btn btn-primary btn-lg btn-block voltar otavio"><i class="fas fa-door-open"></i></button>
        </div>
        <div class="col">
            <button type="button" class="btn btn-primary btn-lg btn-block enviarlista"><i class="fas fa-check"></i>CONFIRMAR</button>
        </div>
    </div>
</div>
@endsection
