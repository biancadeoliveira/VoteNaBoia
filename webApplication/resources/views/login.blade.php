@extends('templates.app')


@section('conteudo')
<div class="container">
    <div class="center-block">
        <img class="logoinicial" src="assets\image\LOGO_VNB-min.png" alt="300">
        <form class="telalogin">
            <div class="form-group">
              <label for="imputEmailLogin">Email</label>
              <input type="email" class="form-control telalogin" placeholder="Digite seu e-mail" id="imputEmailLogin">
            </div>
            <div class="form-group">
              <label for="exampleInputPassword1">Senha</label>
              <input type="password" class="form-control telalogin" id="ImputSenhaLogin" placeholder="Digite sua senha">
            </div>
           <button class="btn btn-lg btn-primary btn-block" type="submit">Entrar</button>
           <div class="form-group form-check telalogin">
            <input type="checkbox" class="form-check-input" id="CheckPermaneceLogado">
            <label class="form-check-label permanecelogado" for="CheckPermaneceLogado">Lembrar-me</label>
          </div>
        </form>
    </div>
</div>


@endsection
