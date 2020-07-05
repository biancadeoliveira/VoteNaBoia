@extends('templates.app')
@extends('templates.menu')


@section('conteudo')
<div class="container">
    <h1 class="votacaosemanal">Votação Semanal</h1>
    <h6>Informações do Restaurante</h6>
    <div class="jumbotron">
        <div class="row">
            <div class="col">
                <img src="assets/image/restaurantes/McDonald's_Golden_Arches.svg-min.png" class="rounded float-left">
            </div>
            <div class="col">
                    <p class="h1 text-left nomeRestaurante otavio">McDonald's</p>
                <div class="col">
                    <p class="h3 text-left tipoRestaurante otavio">Fast Food</p>
                </div>
            </div>
            <div class="col">
                <img src="assets/image/score.png" class="roundedl score otavio">
            </div>
        </div>
        <hr class="my-4"/>
        <div class="row">
            <div class="col">
                <p class="h4 otavio">Formas de Pagamento:</p>
            </div>
            <div class="col-8" style="color:#fff;"">
                <i class="far fa-money-bill-alt" ></i>
                <i class="far fa-credit-card"></i>
                <i class="fas fa-money-check"></i>
                <i class="fab fa-cc-apple-pay"></i>
            </div>
        </div>
        <div class="row">
            <div class="col otavio">
                <p class="h4 otavio">Email:</p>
            </div>
            <div class="col-8">
                <p class="h4 otavio"><a href="#">atendimento@mcdonalds.com.br</a></p>
            </div>
        </div>
        <div class="row">
            <div class="col otavio">
                <p class="h4 otavio">Telefone:</p>
            </div>
            <div class="col-8">
                <p class="h4 otavio" style="color:#fff;">(14) 3333-3333</p>
            </div>
        </div>
        <div class="row">
            <div class="col otavio">
                <p class="h4 otavio">Endereço:</p>
            </div>
        </div>
        <div class="embed-responsive embed-responsive-16by9">
            <iframe class="embed-responsive-item" src="https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d59049.3111975448!2d-49.06759861951608!3d-22.331644875841107!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x0%3A0x6ce14cadc5b48bdf!2sMcDonald&#39;s!5e0!3m2!1spt-BR!2sbr!4v1593104587294!5m2!1spt-BR!2sbr" width="600" height="450" frameborder="0" style="border:0;" allowfullscreen="" aria-hidden="false" tabindex="0">
            </iframe>
        </div>
    </div>
    <p class="h1 text-center otavio" style = "padding-top: 0%;">Você gostaria de adicionar este Restaurante em sua lista?</p>
    <div class="row align-items-center">
        <div class="col">
            <button type="button" class="btn btn-primary btn-lg btn-block voltar otavio"><i class="fas fa-door-open"></i></i></button>
        </div>
        <div class="col">
            <button type="button" class="btn btn-primary btn-lg btn-block enviarlista"><i class="fas fa-check"></i>CONFIRMAR</button>
        </div>
    </div>
</div>

@endsection
