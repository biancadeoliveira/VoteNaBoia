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

    public function cadastraAluno(Request $request)
    {
        $dados = $request->except(['_token']);

        if(isset($dados['SNEnviaEmail'])){
            $dados['SNEnviaEmail'] = 'S';
        }
        else{
            $dados['SNEnviaEmail'] = 'N';
        }

        $dados['SNAtivo'] = 'S';

        $url = "https://localhost:44380/api/aluno/";
        $ret = json_decode($this->requisicao($dados, $url));

        return redirect()->route('login')->with('msg', $ret->message);
    }

    public function fazerLogin(Request $request){
        $dados = $request->except(['_token']);
        $email = $dados['imputEmailLogin'];
        $senha = $dados['ImputSenhaLogin'];

       $url = "https://localhost:44380/api/login/".$email."/".$senha;
       
        $aluno = $this->getAll($url);

        if($aluno->object!=null){
            $request->session()->put('idAluno',$aluno->object->idAluno);
            $request->session()->put('nmAluno',$aluno->object->nmAluno);
            return redirect()->route('menuprincipal');
        }
        else
        {
            return redirect()->route('login')->with('msg', $aluno->message);
        }
    }

    public function listarRestaurantesVotoDiario($idTurma){
        $restaurantes = $this->getAll("https://localhost:44380/api/votodiario/" . $idTurma);


        

        if($restaurantes->object!=null){
            return view('votacaodiaria', [
                'restaurantes' => $restaurantes->object,
                'idTurma' => $idTurma
            ]);
        }
        else
        {
            return redirect()->route('menuprincipal')->with('msg', $restaurantes->message);
        }
    }

    public function visualizaEscolhaVotoDiario($idRestaurante){
        $restaurante = $this->getAll("https://localhost:44380/api/restaurante/" . $idRestaurante);

        if($restaurante->object!=null){
            return view('votacaodiariavisualizacaoescolha', [
                'restaurante' => $restaurante->object
            ]);
        }
        else
        {
            return redirect()->route('menuprincipal')->with('msg', $restaurante->message);
        }
    }

    public function confirmaVotoDiario($idTurma,$idAluno,$idRestaurante){
        $dados = [
            'idRestaurante'=> $idRestaurante,
            'idTurma'=>$idTurma,
            'idAluno'=>$idAluno
        ];
        
        $url = "https://localhost:44380/api/votodiario";
        $ret = json_decode($this->requisicao($dados, $url));

        if($ret->message=='Voto cadastrado com sucesso!')
        {
            return redirect()->route('confirmacaovotacaodiaria')->with('msg', $ret->message);
        }
        else
        {
            return redirect()->route('menuprincipal')->with('msg', $ret->message);
        }
    }

    public function resultadoVotacaoDiaria($idTurma){
        $restaurante = $this->getAll("https://localhost:44380/api/votodiario/resultado/" . $idTurma);

        if($restaurante->object!=null){
            return view('resultadovotacaodiaria', [
                'restaurante' => $restaurante->object
            ]);
        }
        else
        {
            return redirect()->route('menuprincipal')->with('msg', $restaurante->message);
        }
    }
    
    
}
