@extends('templates.app')
@extends('templates.menu')

@section('conteudo')
{{-- Aqui começa o html--}}

<div class="container">
	<h1 class="resultados">Votação Diária</h1>
	<h6> </h6>
	<div class="rounded principalvotacao">
		<div class="row">
			<div class="col">
				<img class="icone votodiario" src="assets/image/restaurantes/McDonald's_Golden_Arches.svg-min.png"> <br>
			</div>
			<div class="col-6">
				<h1 class="nomerestaurante jonas">McDonald's</h1>
				<h1 class="subtitulo">Fast Food</h1>
			</div>
			<div class="col-3 align-self-end score">
				<img class="estrelasjonas diaria" src="assets/image/score.png" >
			</div>
		</div>
		<div class="descricao votodiario"></p>
			<p class="descricao">Forma de Pagamento: <img class="icone forma_pagamento"src="assets/image/forma_pagamento.png" ></p>
			<p class="descricao">E-Mail: <a class="faleconoscodiario" href="#">faleconosco@mcdonalds.com.br</a></p>
			<p class="descricao">Telefone: (14) 3321-2221
				<button type="button" class="btn btn-primary btn-lg telefone"><i class="fa fa-phone" aria-hidden="true">         Ligar</i></button></p></button>
				<p class="descricao">Endereço:</p>
			</div>
			<div class="mapa jonas" align="center" >
				<iframe src="https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d3690.551366313564!2d-49.057760685575175!3d-22.332800723254294!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x94bf67b87d530651%3A0x4846861cabb7fe16!2sMcDonald&#39;s!5e0!3m2!1spt-BR!2sbr!4v1593010076171!5m2!1spt-BR!2sbr" width="800" height="450" frameborder="0" style="border:0;" allowfullscreen="" aria-hidden="false" tabindex="0"></iframe>
				<br>
				<br>
				<br>
			</div>
		</div>
		<div>
			<p class="descricao confirmacao">Você gostaria de comer neste Restaurante?</p>
		</div>
		<div class="principalvotacao">
			<div class="row">
				<div class="col">
					<button type="button" class="btn btn-primary btn-lg btn-block voltar jonas"><i class="fas fa-door-open"></i></i></button>
				</div>
				<div class="col">
					<button type="button" class="btn btn-primary btn-lg btn-block confirmar jonas"><i class="fas fa-check"></i>CONFIRMAR</button>
				</div>
			</div>
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
	</div>
	@endsection
