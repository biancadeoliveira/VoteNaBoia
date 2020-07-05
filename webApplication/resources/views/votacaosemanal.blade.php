@extends('templates.app')
@extends('templates.menu')

@section('conteudo')
<div class="container">
    <h1 class="votacaosemanal">Votação Semanal</h1>
    <h6>Escolha 5 opções de Restaurantes</h6>
    <div class="row align-items-center">
        <div class="col">
            <button type="button" id="btnAdd1" class="btn btn-primary btn-lg btn-block addrestaurante" onclick="mudaCor(document.getElementById('btnAdd1'))">
                <img src="assets/image/restaurantes/McDonald's_Golden_Arches.svg-min.png" class="rounded mx-auto d-block">
                <p class="h1 text-center otavio">McDonald's</p>
                <p class="h3 text-center otavio">Fast Food</p>
                <img src="assets/image/score.png" class="rounded mx-auto d-block">
            </button>
            <button type="button" class="btn btn-info position-absolute"></button>
        </div>
        <div class="col">
            <button type="button" id="btnAdd2" class="btn btn-primary btn-lg btn-block addrestaurante" onclick="mudaCor(document.getElementById('btnAdd2'))">
                <img src="assets/image/restaurantes/McDonald's_Golden_Arches.svg-min.png" class="rounded mx-auto d-block">
                <p class="h1 text-center otavio">McDonald's</p>
                <p class="h3 text-center otavio">Fast Food</p>
                <img src="assets/image/score.png" class="rounded mx-auto d-block">
            </button>
            <button type="button" class="btn btn-info position-absolute"></button>
        </div>
    </div>
    <div class="row align-items-center">
        <div class="col">
            <button type="button" id="btnAdd3" class="btn btn-primary btn-lg btn-block addrestaurante" onclick="mudaCor(document.getElementById('btnAdd3'))">
                <img src="assets/image/restaurantes/McDonald's_Golden_Arches.svg-min.png" class="rounded mx-auto d-block">
                <p class="h1 text-center otavio">McDonald's</p>
                <p class="h3 text-center otavio">Fast Food</p>
                <img src="assets/image/score.png" class="rounded mx-auto d-block">
            </button>
            <button type="button" class="btn btn-info position-absolute"></button>
        </div>
        <div class="col">
            <button type="button" id="btnAdd4" class="btn btn-primary btn-lg btn-block addrestaurante" onclick="mudaCor(document.getElementById('btnAdd4'))">
                <img src="assets/image/restaurantes/McDonald's_Golden_Arches.svg-min.png" class="rounded mx-auto d-block">
                <p class="h1 text-center otavio">McDonald's</p>
                <p class="h3 text-center otavio">Fast Food</p>
                <img src="assets/image/score.png" class="rounded mx-auto d-block">
            </button>
            <button type="button" class="btn btn-info position-absolute"></button>
        </div>
    </div>
    <div class="row align-items-center">
        <div class="col">
            <button type="button" id="btnAdd5" class="btn btn-primary btn-lg btn-block addrestaurante" onclick="mudaCor(document.getElementById('btnAdd5'))">
                <img src="assets/image/restaurantes/McDonald's_Golden_Arches.svg-min.png" class="rounded mx-auto d-block">
                <p class="h1 text-center otavio">McDonald's</p>
                <p class="h3 text-center otavio">Fast Food</p>
                <img src="assets/image/score.png" class="rounded mx-auto d-block">
            </button>
            <button type="button" class="btn btn-info position-absolute"></button>
        </div>
        <div class="col">
            <button type="button" id="btnAdd6" class="btn btn-primary btn-lg btn-block addrestaurante" onclick="mudaCor(document.getElementById('btnAdd6'))">
                <img src="assets/image/restaurantes/McDonald's_Golden_Arches.svg-min.png" class="rounded mx-auto d-block">
                <p class="h1 text-center otavio">McDonald's</p>
                <p class="h3 text-center otavio">Fast Food</p>
                <img src="assets/image/score.png" class="rounded mx-auto d-block">
            </button>
            <button type="button" class="btn btn-info position-absolute"></button>
        </div>
    </div>
    <div class="row align-items-center">
        <div class="col">
            <button type="button" class="btn btn-primary btn-lg btn-block enviarlista"><i class="fas fa-check"></i>ENVIAR LISTA</button>
        </div>
        <div class="col">
            <button type="button" class="btn btn-primary btn-lg btn-block limparlista">LIMPAR TUDO</button>
        </div>
    </div>
<script type="text/javascript">
    function mudaCor(btn)
    {
        if (btn.style.backgroundColor != "rgb(152, 38, 73)")
        {
            btn.style.backgroundColor = "#982649";
        }
        else
        {
            btn.style.backgroundColor = "#A799B7";
        }
    }
</script>
</div>

@endsection
