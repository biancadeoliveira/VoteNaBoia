

@extends('templates.app')
@extends('templates.menu')

@section('conteudo')
{{-- Aqui começa o html--}}

<div class="container">
	<h1 class="resultados jonas">Resultados</h1>
	<h6 class="subtitulo jonas"> Selecione o relatório desejado:</h6>
	<div class="rounded principalvotacao relatorio">
		<form class="form-horizontal" action="/##">
			<div class="form-group">
				<div class="col-sm-offset-2 col-sm-10 ">
					<div class="checkbox">
						<label><input type="checkbox" name="remember">  Restaurantes mais votados</label>
					</div>
				</div>
			</div>
			<div class="form-group">
				<div class="col-sm-offset-2 col-sm-10 ">
					<div class="checkbox">
						<label><input type="checkbox" name="remember">  Restaurantes mais bem avaliados</label>
					</div>
				</div>
			</div>
			<div class="form-group">
				<div class="col-sm-offset-2 col-sm-10 ">
					<div class="checkbox">
						<label><input type="checkbox" name="remember">  Total de votos por Restaurante</label>
					</div>
				</div>
			</div>
			<div class="form-group col-md-4">
				<select id="selecaorestaurante" class="form-control">
					<option selected>Selecione o restaurante...</option>
					<option>McDonald's</option>
					<option>Fogo de Chão</option>
				</select>
			</div>
			<h6 class="subtitulo"> Selecione o período:</h6>
			<div class="row">
				<div class="col jonas">
					Início<br>
					<input id="date" type="date" value="2020-07-01">
				</div>
				<div class="col jonas">
					Fim<br>
					<input id="date" type="date" value="2020-07-01">
				</div>
			</div>
			<div class="form-group">
				<div class="row">
					<div class="col">
						<button type="button" class="btn btn-primary btn-lg pdf voltar jonas"><i class="fas fa-door-open"></i></button>
					</div>
					<div class="col">
						<button type="button" class="btn btn-primary btn-lg pdf jonas"><i class="fa fa-file-excel-o">.PDF</i></button>
					</div>
					<div class="col">
						<button type="button" class="btn btn-primary btn-lg pdf jonas"><i class="fa fa-file-excel-o">.XLS</i>

						</div>
					</div>
				</div>
			</form>
		</div>
	</div>
</div>
<footer >

				<img class="rodape jonas"src="assets/image/footer_img.png">

</footer>
</div>
@endsection
