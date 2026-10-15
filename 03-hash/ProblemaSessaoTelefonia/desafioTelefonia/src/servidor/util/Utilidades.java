package servidor.util;

import java.io.IOException;
import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.Paths;
import java.util.HashMap;
import java.util.List;
import servidor.model.Sessao;

public class Utilidades {

    public static boolean carregarArquivoEmHashMap(String nomeArquivo, HashMap<String, Sessao> sessoes, StringBuilder dadosSessoes) {
        try {
            Path caminho = Paths.get(nomeArquivo);

            List<String> linhas = Files.readAllLines(caminho);

            for (String linha : linhas) {

                dadosSessoes.append(linha).append(System.lineSeparator());

                if (!linha.trim().isEmpty()) {
                    String[] dadosLinha = linha.split(";");

                    if (dadosLinha.length >= 2) {
                        Sessao sessao = new Sessao(dadosLinha[0], dadosLinha[1]);
                        sessoes.put(sessao.numeroCelular, sessao);
                    }
                }
            }

            return true;
        } catch (IOException e) {
            System.err.println("Erro ao carregar arquivo: " + e.getMessage());
            return false;
        }
    }
}