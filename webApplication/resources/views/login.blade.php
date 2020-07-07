@extends('templates.app')


@section('conteudo')
<div class="container">
    <div class="center-block">
        <img class="logoinicial" src="assets\image\LOGO_VNB-min.png" alt="300">
        <form class="telalogin" action="{{route('login')}}" method="POST">
        @csrf
            <div class="form-group">
              <label for="imputEmailLogin">Email</label>
              <input type="email" value="hellen@gmail.com" class="form-control telalogin" placeholder="Digite seu e-mail" id="imputEmailLogin" name="imputEmailLogin">
            </div>
            <div class="form-group">
              <label for="exampleInputPassword1">Senha</label>
              <input type="password" value="12345" class="form-control telalogin" id="ImputSenhaLogin" placeholder="Digite sua senha" name="ImputSenhaLogin">
            </div>
           <button class="btn btn-lg btn-primary btn-block" type="submit">Entrar</button>
           <div class="form-group form-check telalogin">
            <input type="checkbox" class="form-check-input" id="CheckPermaneceLogado">
            <label class="form-check-label permanecelogado" for="CheckPermaneceLogado">Lembrar-me</label>
          </div>
        </form>
        @if (Session::has('msg'))
            <div class="col-md-12">
            <div class="alert alert-primary">{{Session::get('msg')}}</div>
            </div>
        @endif
    </div>
</div>


@endsection
