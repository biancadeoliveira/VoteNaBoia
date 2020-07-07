@extends('templates.app')


@section('conteudo')
<div class="container">
    <div class="row menuprincipal">
        <div class="col 8"><img src="assets\image\otavioavatar.png" class="avatarmenuprincipal"></div>
        <div class="col 8 ">
            <p class="bemvindomenuprincipal">Bem vindo,<br><b class="nomeusuario">Otávio</b>
        </div>
        <div class="col icon"><i class="fas fa-sign-out-alt menuprincipal"></i></div>
        <div class="col 8"><img src="assets\image\logo-vote.png" alt="logovotenaboia" class="logomenuprincipal"></div>
      </div>
      @if (Session::has('idAluno'))
        <div class="col-md-12">
        <div class="alert alert-primary">{{Session::get('nmAluno')}}</div>
        </div>
    @endif
    @if (Session::has('msg'))
        <div class="col-md-12">
        <div class="alert alert-primary">{{Session::get('msg')}}</div>
        </div>
    @endif
    <p class="dataatual">Segunda-feira, 8 de junho de 2020</p>
    <button class="btn btn-lg btn-primary btn-block menuprincipal" type="button"><i class="fas fa-calendar-day menuprincipal"></i><a href="{{ route('restaurantesVotoDiario',1) }}">Votação Diaria</a></button>
    <button class="btn btn-lg btn-primary btn-block menuprincipal" type="button"><i class="fas fa-calendar-week menuprincipal"></i>Votação</button>
    <button class="btn btn-lg btn-primary btn-block menuprincipal result" type="button"><i class="fas fa-calendar-week menuprincipal "></i><a href="{{ route('resultados') }}">Resultados</a></button>
    <button class="btn btn-lg btn-primary btn-block menuprincipal configs" type="button"><i class="fas fa-cog config"></i>Configurações</button>



</div>


@endsection
