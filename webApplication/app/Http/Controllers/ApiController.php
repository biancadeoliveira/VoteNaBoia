<?php

namespace App\Http\Controllers;

use Illuminate\Http\Request;

class ApiController extends Controller
{
    public function listarRestaurantes($id){
        
        $restaurantes = $this->getAll("https://localhost:44380/api/restaurante/turma/" . $id);
        //$turma = $this->getAll("https://localhost:44380/api/restaurante/turma/1");
        // echo '<pre>';
        // var_dump($restaurantes);
        // die;

        return view('restaurantes', [
            'restaurantes' => $restaurantes->object,
            'idTurma' => $id
        ]);
    }

    public function cadastrarRestaurante(Request $request){
        $dados = $request->except(['_token']);
        
        if(isset($dados['snAtivo'])){
            $dados['snAtivo'] = 'S';
        }
        else{
            $dados['snAtivo'] = 'N';
        }

        $url = "https://localhost:44380/api/restaurante";
        $ret = json_decode($this->requisicao($dados, $url));

        return redirect()->route('restaurantes', $dados['idTurma'])->with('msg', $ret->message);
    }

    private function getAll($url){

        
        $ch = curl_init(); //abre a conexão curl
            //Paramêtros
            curl_setopt($ch, CURLOPT_URL, $url);
            curl_setopt($ch, CURLOPT_SSL_VERIFYPEER, FALSE);
            curl_setopt($ch, CURLOPT_RETURNTRANSFER, 1);
            curl_setopt($ch, CURLOPT_HTTPHEADER, array(
                "Content-Type: application/json",
            ));
            //
            $output = curl_exec($ch); //executa a requisição e armazena o retorno em uma variavel

            curl_close($ch);//fecha a conexão

            $dados = json_decode($output); //cria um objeto a partir dos dados retornados

            // echo '<pre>';
            // var_dump($dados->object);
            // die;
             
            return $dados;

    }

    public function requisicao($dados, $url){

        $dados = json_encode($dados);//Transfora todos os dados vindos do formulário em JSON

        $curl = curl_init();

          curl_setopt_array($curl, array(
            CURLOPT_URL => $url,
            CURLOPT_RETURNTRANSFER => true,
            CURLOPT_SSL_VERIFYPEER=> FALSE,
            CURLOPT_CUSTOMREQUEST => "POST",
            CURLOPT_POSTFIELDS => $dados, //dados a enviar
            CURLOPT_HTTPHEADER => array(
              "Content-Type: application/json",
            ),
          ));

          $response = curl_exec($curl);
          
          $err = curl_error($curl);

          return $response;
          //echo '<pre>';
          //print_r($response);
    }
}
