@extends('templates.app')
@extends('templates.menu')

@section('conteudo')
<div class="container">
    <h1 class="votacaosemanal">Configurações</h1>
    <h3 class="moderacao"><i class="fas fa-user-shield" style="margin-right: 2%;"></i>Controles de Moderação</h3>
    <div class="row align-items-center">
        <div class="col">
            <button type="button" class="btn btn-primary btn-lg btn-block manage otavio"><i class="fas fa-user-check"></i>&nbsp Aprovar Novos Usuários</button>
        </div>
    </div>
    <div class="row align-items-center">
        <div class="col">
            <button type="button" class="btn btn-primary btn-lg btn-block manage otavio"><i class="fas fa-utensils"></i>  &nbsp Gerenciar Restaurantes</button>
        </div>
    </div>
    <form>
        <div class="form-group">
            <label for="FormControlSelect1">Quantidade de Restaurantes na Semana</label>
            <select class="form-control" id="FormControlSelect1">
            <option>1</option>
            <option>2</option>
            <option>3</option>
            <option>4</option>
            <option>5</option>
            <option>6</option>
            </select>
        </div>
        <div class="form-group">
            <label for="idSala">ID da Sala</label>
            <input class="form-control" type="text" placeholder="">
        </div>
        <div class="form-group">
            <label for="nomeSala">Nome da Sala</label>
            <input class="form-control" type="text" placeholder="">
        </div>
    </form>
    <div class="row align-items-center">
        <div class="col">
            <button type="button" class="btn btn-primary btn-lg btn-block voltar otavio"><i class="fas fa-door-open"></i></button>
        </div>
        <div class="col">
            <button type="button" class="btn btn-primary btn-lg btn-block enviarlista"><i class="fas fa-check"></i>CONFIRMAR</button>
        </div>
    </div>
</div>
@endsection
