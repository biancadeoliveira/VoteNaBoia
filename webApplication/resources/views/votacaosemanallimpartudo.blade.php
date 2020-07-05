

@extends('templates.app')
@extends('templates.menu')

@section('conteudo')
{{-- Aqui começa o html--}}

<div class="container">
	<h1 class="resultados">Resultados</h1>
	<h6 class="subtitulo"> Votação Diária</h6>
	<div class="rounded principalvotacao">
		<div class="row">
			<div class="col">
				<img class="icone votodiario"src="assets/image/restaurantes/McDonald's_Golden_Arches.svg-min.png"> <br>
			</div>
			<div class="col">
				<h1 class="nomerestaurante jonas">McDonald's</h1>
				<h1 class="subtitulo jonas">Fast Food</h1>
			</div>
			<div class="col score">
				<img src="assets/image/score.png" class="roundedl score otavio dois">
			</div>
		</div>
		<div class="descricao votodiario"></p>
			<p class="descricao">Forma de Pagamento: <img class="icone forma_pagamento"src="assets/image/forma_pagamento.png" ></p>
			<p class="descricao">Endereço:</p>
		</div>
		<div class="mapa" align="center" >
			<iframe src="https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d3690.551366313564!2d-49.057760685575175!3d-22.332800723254294!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x94bf67b87d530651%3A0x4846861cabb7fe16!2sMcDonald&#39;s!5e0!3m2!1spt-BR!2sbr!4v1593010076171!5m2!1spt-BR!2sbr" width="800" height="450" frameborder="0" style="border:0;" allowfullscreen="" aria-hidden="false" tabindex="0"></iframe>
			<div class="row">
				<div class="col">
					<h1 class="nomerestaurante subtitulo">Total de Votos:</h1>
				</div>
				<div class="col">
					<h1 class="nomerestaurante somatoria">12</h1>
				</div>
			</div>
		</div>
	</div>
	<div class="row align-items-center">
		<button type="button" class="btn btn-primary btn-lg btn-block listafinal resultado">
			<div class="row">
				<div class="col-1">
					<img src="assets/image/grupo 28.png" class="ranking">
				</div>
				<div class="col-2">
					<img src="assets/image/restaurantes/McDonald's_Golden_Arches.svg-min.png" class="rounded float-right logo">
				</div>
				<div class="col align-self-center">
					<p class="h1 text-left">McDonald's</p>
				</div>
				<div class="col-3 align-self-center score">
					<p class="h1 text-left">4</p>
				</div>
			</div>
		</button>
	</div>
	<div class="row align-items-center">
		<button type="button" class="btn btn-primary btn-lg btn-block listafinal resultado">
			<div class="row">
				<div class="col-1">
					<img src="assets/image/grupo 29.png" class="ranking">
				</div>
				<div class="col-2">
					<img src="assets/image/restaurantes/McDonald's_Golden_Arches.svg-min.png" class="rounded float-right logo">
				</div>
				<div class="col align-self-center">
					<p class="h1 text-left">McDonald's</p>
				</div>
				<div class="col-3 align-self-center score">
					<p class="h1 text-left">3</p>
				</div>
			</div>
		</button>
	</div>




	<button type="button" class="btn btn-primary btn-lg btn-block voltar resultado otavio dois"><i class="fas fa-door-open"></i></button>


</div>



<footer >

				<img class="rodape"src="assets/image/footer_img.png">


		</div>
	</div>
</footer>
</div>
@endsection
