package servidor.service;

import java.rmi.RemoteException;
import java.rmi.server.UnicastRemoteObject;
import servidor.model.Sessao;
import servidor.model.TabelaHash;

public class ServicoTelefoniaImpl extends UnicastRemoteObject implements ServicoTelefonia {

    private final TabelaHash tabela;

    public ServicoTelefoniaImpl(TabelaHash tabela, int porta) throws RemoteException {
        super(porta);
        this.tabela = tabela;
    }

    @Override
    public String pesquisar(String numeroCelular) throws RemoteException {
        if (numeroCelular == null || numeroCelular.trim().isEmpty()) {
            return null;
        }

        Sessao sessao = tabela.pesquisar(numeroCelular.trim());
        return sessao == null ? null : sessao.dadosSessao;
    }
}
