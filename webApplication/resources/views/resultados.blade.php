@extends('templates.app')
@extends('templates.menu')

@section('conteudo')
{{-- Aqui começa o html--}}
<div class="container">
    <h1 class="resultados">Resultados</h1>
        <div class="row align-items-center">
            <div class="col">
                <button type="button" class="btn btn-primary btn-lg btn-block resultado">Resultado Votação Diária<br><i class="fas fa-calendar-day"></i></button>
            </div>
            <div class="col">
                <button type="button" class="btn btn-primary btn-lg btn-block resultado">Resultado Votação Seamanal<br><i class="fas fa-calendar-week"></i></button>
            </div>
        </div>
        <button type="button" class="btn btn-primary btn-lg btn-block relatorios"><i class="far fa-newspaper big"></i>Relatórios</button>
    <div class="ultimosvotosdiarios">
        <h1 class="resultados meusultimosvotos">Meus últimos votos diários</h1>
        <div class="row border dias">
            <div class="col-sm">
                <p class="diasdasemana"><i class="fas fa-calendar-day paddingrigth"></i>Sexta-Feira</p>
            </div>
            <div class="col-sm">
                <img class="rounded float-right restaurante"src="assets/image/restaurantes/McDonald's_Golden_Arches.svg-min.png">
            </div>
            <div class="col-sm">
                <p class="diasdasemana nomerestaurante">McDonald's</p>
            </div>
        </div>
        <div class="row border dias">
            <div class="col-sm">
                <p class="diasdasemana"><i class="fas fa-calendar-day paddingrigth"></i>Sexta-Feira</p>
            </div>
            <div class="col-sm">
                <img class="rounded float-right restaurante"src="assets/image/restaurantes/McDonald's_Golden_Arches.svg-min.png">
            </div>
            <div class="col-sm">
                <p class="diasdasemana nomerestaurante">McDonald's</p>
            </div>
        </div>
        <div class="row border dias">
            <div class="col-sm">
                <p class="diasdasemana"><i class="fas fa-calendar-day paddingrigth"></i>Sexta-Feira</p>
            </div>
            <div class="col-sm">
                <img class="rounded float-right restaurante"src="assets/image/restaurantes/McDonald's_Golden_Arches.svg-min.png">
            </div>
            <div class="col-sm">
                <p class="diasdasemana nomerestaurante">McDonald's</p>
            </div>
        </div>
        <div class="row border dias">
            <div class="col-sm">
                <p class="diasdasemana"><i class="fas fa-calendar-day paddingrigth"></i>Sexta-Feira</p>
            </div>
            <div class="col-sm">
                <img class="rounded float-right restaurante"src="assets/image/restaurantes/McDonald's_Golden_Arches.svg-min.png">
            </div>
            <div class="col-sm">
                <p class="diasdasemana nomerestaurante">McDonald's</p>
            </div>
        </div>
        <div class="row border dias">
            <div class="col-sm">
                <p class="diasdasemana"><i class="fas fa-calendar-day paddingrigth"></i>Sexta-Feira</p>
            </div>
            <div class="col-sm">
                <img class="rounded float-right restaurante"src="assets/image/restaurantes/McDonald's_Golden_Arches.svg-min.png">
            </div>
            <div class="col-sm">
                <p class="diasdasemana nomerestaurante">McDonald's</p>
            </div>
        </div>
    </div>

</div>
{{-- Aqui finaliza o HTML --}}


@endsection
