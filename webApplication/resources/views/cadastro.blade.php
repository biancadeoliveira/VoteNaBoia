@extends('templates.app')


@section('conteudo')

<div class="container">
    <div class="center-block cadastro">
        <img class="logoinicial" src="assets\image\LOGO_VNB-min.png" alt="300">
        <form class="telaregistro">
            <div class="row">
                <div class="col">
                    <i class="fas fa-user-astronaut cadastro"></i>
                </div>
                <div class="col nome">
                    <label for="imputnomeRegistro">Nome</label>
                    <input type="text" class="form-control telaregistro" placeholder="Digite seu nome completo">
                </div>
            </div>
            <div class="form-group">
              <label for="imputEmailRegistro">Email</label>
              <input type="email" class="form-control telaRegistro" placeholder="Digite seu e-mail" id="imputEmailRegistro">
            </div>
            <div class="form-group">
              <label for="exampleInputPassword1">Senha</label>
              <input type="password" class="form-control telaRegistro" id="ImputSenhaRegistro" placeholder="Digite sua senha">
            </div>
            <div class="form-group">
                <label for="exampleInputPassword1">Confirme sua Senha</label>
                <input type="password" class="form-control telaRegistro" id="ImputSenhaConfirmaRegistro" placeholder="Repita sua senha">
              </div>
            <div class="form-group form-check telaRegistro">
                <input type="checkbox" class="form-check-input" id="CheckPermaneceLogado">
                <label class="form-check-label permanecelogado" for="CheckPermaneceLogado">Desejo receber notificações por e-mail</label>
            </div>
            <div class="row">
                <div class="col botaovoltar">
                    <button class="btn btn-lg btn-primary btn-block voltarcadastro" type="submit"><i class="fas fa-angle-left"></i></button>
                </div>
                <div class="col-8 botaocadastrar">
                    <button class="btn btn-lg btn-primary btn-block cadastro" type="submit">Cadastrar</button>
                </div>
        </form>
    </div>
</div>


@endsection
