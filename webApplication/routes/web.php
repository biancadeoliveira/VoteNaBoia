<?php

use Illuminate\Support\Facades\Route;

/*
|--------------------------------------------------------------------------
| Web Routes
|--------------------------------------------------------------------------
|
| Here is where you can register web routes for your application. These
| routes are loaded by the RouteServiceProvider within a group which
| contains the "web" middleware group. Now create something great!
|
*/

Route::get('/', function () { // ok
    return view('home');
});

Route::get('/login', function () { // ok
    return view('login');
});
Route::post('/login', 'ApiController@fazerLogin')->name('login');

Route::get('/cadastro', function () { // ok
    return view('cadastro');
});

Route::get('/configuracoes', function () { // ok
    return view('configuracoes');
});

Route::get('/configuracoeseditarnotificacoes', function () { //ok
    return view('configuracoeseditarnotificacoes');
});

Route::get('/configuracoeseditarperfil', function () { // ok
    return view('configuracoeseditarperfil');
});

Route::get('/configuracoesmoderador', function () { // ok
    return view('configuracoesmoderador');
});

Route::get('/confirmacaovotacaodiaria', function () { // ok
    return view('confirmacaovotacaodiaria');
})->name('confirmacaovotacaodiaria');

Route::get('/loginsucess', function () { //ok
    return view('loginsucess');
});

Route::get('/menuprincipal', function () { // ok
    return view('menuprincipal');
})->name('menuprincipal');

Route::get('/resultados', function () { // ok
    return view('resultados');
})->name('resultados');

Route::get('/resultadosum', function () { // ok
    return view('resultadosum');
});

Route::get('/resultadovotacaodiaria', function () { // ok
    return view('resultadovotacaodiaria');
});

Route::get('/resultadovotacaodiaria/{idTurma}', 'ApiController@resultadoVotacaoDiaria')->name('resultadovotacaodiaria');

Route::get('/votacaodiaria', function () { // ok
    return view('votacaodiaria');
});
Route::get('/votacaodiaria/{idTurma}', 'ApiController@listarRestaurantesVotoDiario')->name('restaurantesVotoDiario');

//Route::get('/votoVotoDiario/{idRestaurante}/{idTurma}/{idAluno}', 'ApiController@votoVotoDiario')->name('votoVotoDiario');

Route::get('/votacaodiariavisualizacaoescolha', function () { // ok
    return view('votacaodiariavisualizacaoescolha');
});

Route::get('/votacaodiariavisualizacaoescolha/{idRestaurante}', 'ApiController@visualizaEscolhaVotoDiario')->name('visualizaEscolhaVotoDiario');

Route::get('/confirmaVotoDiario/{idTurma}/{idAluno}/{idRestaurante}', 'ApiController@confirmaVotoDiario')->name('confirmaVotoDiario');

Route::get('/votacaosemanal', function () { //ok
    return view('votacaosemanal');
});

Route::get('/votacaosemanalconfirmacao', function () { //ok
    return view('votacaosemanalconfirmacao');
});

Route::get('/votacaosemanallimpartudo', function () { //OK
    return view('votacaosemanallimpartudo');
});

Route::get('/votacaosemanallistarestaurante', function () { //ok
    return view('votacaosemanallistarestaurante');
});

Route::get('/votacaosemanalinforestaurante', function () { //ok
    return view('votacaosemanalinforestaurante');
});

Route::get('/votacaosemanalprevisualizacaorestaurante', function () { //ok
    return view('votacaosemanalprevisualizacaorestaurante');
});

Route::get('/restaurantes/{id}', 'ApiController@listarRestaurantes')->name('restaurantes');
Route::post('/restaurantes', 'ApiController@cadastrarRestaurante')->name('restaurante.store');