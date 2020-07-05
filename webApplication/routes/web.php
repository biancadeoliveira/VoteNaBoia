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

Route::get('/', function () {
    return view('home');
});

Route::get('/login', function () {
    return view('login');
});

Route::get('/cadastrar', function () {
    return view('cadastro');
});

Route::get('/configuracoes', function () {
    return view('configuracoes');
});

Route::get('/confirmacaovotacaodiaria', function () {
    return view('confirmacaovotacaodiaria');
});

Route::get('/loginsucess', function () {
    return view('loginsucess');
});

Route::get('/menuprincipal', function () {
    return view('menuprincipal');
});

//Route::get('/resultados', function () {
//    return view('resultados');
//});

Route::get('/restaurantes/{id}', 'ApiController@listarRestaurantes')->name('restaurantes');
Route::post('/restaurantes', 'ApiController@cadastrarRestaurante')->name('restaurante.store');

Route::get('/resultadosum', function () {
    return view('resultadosum');
});

Route::get('/votacaodiaria', function () {
    return view('votacaodiaria');
});

Route::get('/votacaodiariavisualizacaoesolha', function () {
    return view('votacaodiariavisualizacaoescolha');
});

Route::get('/votacaosemanal', function () {
    return view('votacaosemanal');
});

Route::get('/votacaosemanalconfirmacao', function () {
    return view('votacaosemanalconfirmacao');
});

Route::get('/votacaosemanallimpartudo', function () {
    return view('votacaosemanallimpartudo');
});

Route::get('/votacaosemanallistarestaurante', function () {
    return view('votacaosemanallistarestaurante');
});

Route::get('/votacaosemanalmcdonalds', function () {
    return view('votacaosemanalmcdonalds');
});

Route::get('/votacaosemanalprevisualizacaorestaurante', function () {
    return view('votacaosemanalprevisualizacaorestaurante');
});
