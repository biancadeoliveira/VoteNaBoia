@extends('templates.app')


@section('conteudo')
<div class="container">
    <div class="center-block loginsucess">
        <img class="logoinicial" src="assets\image\LOGO_VNB-min.png" alt="300">
        <i class="far fa-check-circle loginsucess"></i>
        <p class="text-center">Cadastro efetuado com sucesso! Aguarde o e-mail de confirmação para fazer o login.</p>
        <div class="row">
            <div class="col botaovoltar">
                <button class="btn btn-lg btn-primary btn-block voltarcadastro loginsucess" type="submit"><i class="fas fa-angle-left"></i></button>
        </div>
    </div>
</div>


@endsection
