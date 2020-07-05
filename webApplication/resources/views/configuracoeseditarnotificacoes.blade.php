@extends('templates.app')
@extends('templates.menu')

@section('conteudo')
<div class="container">
    <h1 class="votacaosemanal">Configurações</h1>
    <div class="row ">
        <div class="col">
            <img class="rounded float-left" src="assets/image/profile_pic_img.png" style="margin-top: 7%;">
        </div>
        <div class="col">
            <h1 style="color: #323232">Otávio</h1>
            <h5 style="color: #323232">MODERADOR</h5>
        </div>
    </div>
    <form>
        <div class="row ">
            <div class="col">
                <div class="custom-control form-control-lg custom-checkbox">
                    <input type="checkbox" class="custom-control-input" id="customCheck1">
                    <label class="custom-control-label otavio" for="customCheck1">  &nbsp Ativar Notificações</label>
                </div>
            </div>
        </div>
        <hr/>
        <div class="row ">
                        <div class="col">
                <div class="custom-control form-control-lg custom-checkbox">
                    <input type="checkbox" class="custom-control-input" id="customCheck2">
                    <label class="custom-control-label otavio" for="customCheck2">  &nbsp Início da Votação Diária</label>
                </div>
            </div>
        </div>
        <div class="row ">
                        <div class="col">
                <div class="custom-control form-control-lg custom-checkbox">
                    <input type="checkbox" class="custom-control-input" id="customCheck3">
                    <label class="custom-control-label otavio" for="customCheck3">  &nbsp Início da Votação Semanal</label>
                </div>
            </div>
        </div>
        <div class="row ">
                        <div class="col">
                <div class="custom-control form-control-lg custom-checkbox">
                    <input type="checkbox" class="custom-control-input" id="customCheck4">
                    <label class="custom-control-label otavio" for="customCheck4">  &nbsp Resultado da Votação Diária</label>
                </div>
            </div>
        </div>
        <div class="row ">
                        <div class="col">
                <div class="custom-control form-control-lg custom-checkbox">
                    <input type="checkbox" class="custom-control-input" id="customCheck5">
                    <label class="custom-control-label otavio" for="customCheck5">  &nbsp Resultado da Votação Semanal</label>
                </div>
            </div>
        </div>
        <div class="row ">
                        <div class="col">
                <div class="custom-control form-control-lg custom-checkbox">
                    <input type="checkbox" class="custom-control-input" id="customCheck6">
                    <label class="custom-control-label otavio" for="customCheck6">  &nbsp Novidades do Sistema</label>
                </div>
            </div>
        </div>
    </form>
    <div class="row ">
        <div class="col">
            <button type="button" class="btn btn-primary btn-lg btn-block voltar otavio"><i class="fas fa-door-open"></i></button>
        </div>
        <div class="col">
            <button type="button" class="btn btn-primary btn-lg btn-block enviarlista otavio"><i class="fas fa-check"></i>CONFIRMAR</button>
        </div>
    </div>
</div>
@endsection
