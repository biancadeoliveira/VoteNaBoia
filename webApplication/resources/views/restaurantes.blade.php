@extends('templates.app')
@extends('templates.menu')


@section('conteudo')
    <div class="container">
        <div class="row">
            <div class="col-md-12 mt-4">
                <h2>Restaurantes</h2>
                <hr>
            </div>
            @if (Session::has('msg'))
                <div class="col-md-12">
                <div class="alert alert-primary">{{Session::get('msg')}}</div>
                </div>
            @endif
            <div class="col-md-6 mt-4">
                <p>Lista de restaurantes cadastrados para a turma $turma->nome</p>
                <table class="table table-responsive table-striped">
                    <thead class='thead-dark'>
                        <tr>
                            <th class="text-center w-25">Nome</th>
                            <th class="text-center w-25">Tipo</th>
                            <th class="text-center w-25">Endereço</th>
                            <th class="text-center">Ativo</th>

                        </tr>
                    </thead>
                    <tbody>
                        @foreach($restaurantes as $r)
                        <tr>
                            <td class="text-center">{{$r->nmNome}}</td>
                            <td class="text-center">{{$r->nmTipo}}</td>
                            <td class="text-center">{{$r->endereco}}</td>
                            <td class="text-center">{{$r->snAtivo}}</td>
                            
                            <!--<td> @foreach($r->pagamentoRestaurante as $p)
                                <p> {{$p->nmTipo}}
                                 @endforeach
                            </td>-->
                            
                        </tr>
                        @endforeach
                    </tbody>
                </table>
            </div>
            <div class="col-md-6 mt-4">
                <p>Cadastrar novo restaurante</p>
            <form action="{{route('restaurante.store')}}" method="POST">
                    @csrf
                    <div class="form-row">
                        <div class="col">
                            <div class="form-group">
                                <label for="nmNome">Nome do restaurante</label>
                                <input type='text' id='nmNome' name='nmNome' class="form-control">
                            </div>
                        </div>
                        <div class="col">
                            <div class="form-group">
                                <label for="nmTipo">Tipo</label>
                                <input type='text' id='nmTipo' name='nmTipo' class="form-control">
                            </div>
                        </div>
                    </div>

                    <div class="form-group">
                        <label for="endereco">Endereço</label>
                        <input type='text' id='endereco' name='endereco' class="form-control">
                    </div>
                    
                    <div class="form-row">
                        <div class="col">
                            <div class="form-group">
                                <label for="noTelefone">Telefone</label>
                                <input type='text' id='noTelefone' name='noTelefone' class="form-control">
                            </div>
                        </div>

                        <div class="col">
                            <div class="form-group">
                                <label for="link">Link útil</label>
                                <input type='text' id='link' name='link' class="form-control">
                            </div>
                        </div>
                    </div>

                    <div class="form-group">
                        <label for="email">E-mail</label>
                        <input type='text' id='email' name='email' class="form-control">
                    </div>

                    <div class="form-group pl-4">
                        <input type="checkbox" class="form-check-input" name='snAtivo' id="snAtivo">
                        <label class="form-check-label" for="snAtivo">Ativo</label>
                    </div>

                    <input type="hidden" value="{{$idTurma}}" name='idTurma'>

                    <button type="submit" class="btn btn-dark">Cadastrar</button>
                </form>
            </div>
        </div>
    </div>


@endsection
