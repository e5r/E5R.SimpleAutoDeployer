E5R.SimpleAutoDeployer
======================

Simple Automatic Deployer

Sistema simples e automático para implementação de softwares.

## Ideia basica

* e5rsad.exe escutando as mudanças nos diretórios:
    * __/wainting__: Tarefas em espera [[provavelmente só esta é suficiente]]
    * __/initiated__: Tarefas iniciadas
    * __/completed__: Tarefas completadas
* As tarefas são descritas em arquivos _JSON_;
* e5rsad.exe mantem uma fila das tarefas
* Quando um arquivo novo é detectado um objeto __TaskBase__ é criado e incluído na fila`__waiting__;
* Após a conclusão de uma tarefa, e/ou de tempos em tempos a próxima tarefa é iniciada:
    * Aí a mesma é removida do diretório (e da fila) __waiting__ e movida para __initiated__;
* Quando uma tarefa é finalizada (com sucesso ou erro) a mesma é movida da fila (e do diretório) __initiated__ para __completed__;
    * E a próxima tarefa (se ouver é iniciada)
