package servidor.model;

import java.util.HashMap;
import java.util.HashSet;
import java.util.Set;

/**
 * classe para sessoes de telefonia
 * @author laboratorio
 */
public class TabelaHash {
    /**
     * sessoes é um HashMap com chave celular e conteúdo sendo dados da sessão
     */
    public HashMap<String, Sessao> sessoes;
    private final Set<String> numerosCelulares;
     
    
    public TabelaHash() {
        sessoes = new HashMap<>();
        numerosCelulares = new HashSet<>();
    }

    public void limpar() {
        sessoes.clear();
        numerosCelulares.clear();
    }

    public void adicionar(Sessao sessao) {
        sessoes.put(sessao.numeroCelular, sessao);
        numerosCelulares.add(sessao.numeroCelular);
    }

    public Sessao pesquisar(String numeroCelular) {
        if (!numerosCelulares.contains(numeroCelular)) {
            return null;
        }
        return sessoes.get(numeroCelular);
    }
}
