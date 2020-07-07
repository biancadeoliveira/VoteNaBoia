@extends('templates.app')
@extends('templates.menu')

@section('conteudo')
<div class="container">
    @if (Session::has('msg'))
        <div class="col-md-12">
        <div class="alert alert-primary">{{Session::get('msg')}}</div>
        </div>
    @endif
    <h1 class="votacaosemanal">Votação Diária</h1>
    @foreach($restaurantes as $r)
    <div class="row align-items-center">
        <button type="button" class="btn btn-primary btn-lg btn-block listafinal jonas">
            <div class="row">
                <div class="col-5">
                    <img class="icone votodiario" src="assets/image/restaurantes/McDonald's_Golden_Arches.svg-min.png" class="rounded float-right">
                </div> 
                <div class="col align-self-center">
                    <p class="h1 text-left jonas"><a href="{{route('visualizaEscolhaVotoDiario',$r->idRestaurante)}}">{{$r->nmNome}}</a></p>
                </div>
                <div class="col-3 align-self-center score">
                    <img class="estrelasjonas dois" src="assets/image/score.png" >
                </div>
            </div>
        </button>
    </div>
    @endforeach
    <!--<div class="row align-items-center">
        <button type="button" class="btn btn-primary btn-lg btn-block listafinal jonas">
            <div class="row">
                <div class="col-5">
                    <img class="icone votodiario" src="assets/image/restaurantes/McDonald's_Golden_Arches.svg-min.png" class="rounded float-right">
                </div>
                <div class="col align-self-center">
                    <p class="h1 text-left jonas">McDonald's</p>
                </div>
                <div class="col-3 align-self-center score">
                    <img class="estrelasjonas dois" src="assets/image/score.png" >
                </div>
            </div>
        </button>
    </div>
    <div class="row align-items-center">
        <button type="button" class="btn btn-primary btn-lg btn-block listafinal jonas">
            <div class="row">
                <div class="col-5">
                    <img class="icone votodiario" src="assets/image/restaurantes/McDonald's_Golden_Arches.svg-min.png" class="rounded float-right">
                </div>
                <div class="col align-self-center">
                    <p class="h1 text-left jonas">McDonald's</p>
                </div>
                <div class="col-3 align-self-center score">
                    <img class="estrelasjonas dois" src="assets/image/score.png" >
                </div>
            </div>
        </button>
    </div>
    <div class="row align-items-center">
        <button type="button" class="btn btn-primary btn-lg btn-block listafinal jonas">
            <div class="row">
                <div class="col-5">
                    <img class="icone votodiario" src="assets/image/restaurantes/McDonald's_Golden_Arches.svg-min.png" class="rounded float-right">
                </div>
                <div class="col align-self-center">
                    <p class="h1 text-left jonas">McDonald's</p>
                </div>
                <div class="col-3 align-self-center score">
                    <img class="estrelasjonas dois" src="assets/image/score.png" >
                </div>
            </div>
        </button>
    </div>
    <div class="row align-items-center">
        <button type="button" class="btn btn-primary btn-lg btn-block listafinal jonas">
            <div class="row">
                <div class="col-5">
                    <img class="icone votodiario" src="assets/image/restaurantes/McDonald's_Golden_Arches.svg-min.png" class="rounded float-right">
                </div>
                <div class="col align-self-center">
                    <p class="h1 text-left jonas">McDonald's</p>
                </div>
                <div class="col-3 align-self-center score">
                    <img class="estrelasjonas dois" src="assets/image/score.png" >
                </div>
            </div>
        </button>
    </div>
    <div class="row align-items-center">
        <button type="button" class="btn btn-primary btn-lg btn-block listafinal jonas">
            <div class="row">
                <div class="col-5">
                    <img class="icone votodiario" src="assets/image/restaurantes/McDonald's_Golden_Arches.svg-min.png" class="rounded float-right">
                </div>
                <div class="col align-self-center">
                    <p class="h1 text-left jonas">McDonald's</p>
                </div>
                <div class="col-3 align-self-center score">
                    <img class="estrelasjonas dois" src="assets/image/score.png" >
                </div>
            </div>
        </button>
    </div>
    <div class="row align-items-center">
        <button type="button" class="btn btn-primary btn-lg btn-block listafinal jonas">
            <div class="row">
                <div class="col-5">
                    <img class="icone votodiario" src="assets/image/restaurantes/McDonald's_Golden_Arches.svg-min.png" class="rounded float-right">
                </div>
                <div class="col align-self-center">
                    <p class="h1 text-left jonas">McDonald's</p>
                </div>
                <div class="col-3 align-self-center score">
                    <img class="estrelasjonas dois" src="assets/image/score.png" >
                </div>
            </div>
        </button>
    </div> -->
    <footer >
        <div class="descricao">
            <div class="row">
                <div class="col">
                    <img class="rodape"src="assets/image/footer_img.png">
                </div>
            </div>
        </div>
    </footer>
</div>
<div></div>
</div>
@endsection
