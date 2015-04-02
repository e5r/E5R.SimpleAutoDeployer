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

### Arquivo de tarefas

Dentro de cada diretório, uma tarefa (mudar para "um arquivo de deploy") é descrita por um arquivo __JSON__.

```json
{
   "deploy_id": "000001",
   "steps": [
      {
         "task": "CheckoutSVN",
         "params": {
            "repository": "http://svn.company.com",
            "user": "UserName",
            "password": "Password",
            "path": "tags/v1.0.1",
            "revision": "767687678"
         }
      },
      {
         "task": "MSBuild",
         "params": {
            "target": "Main.sln",
            "extra_params": "/NoLogo /NoConsoleLogger"
         }
      },
      {
         "task": "script_powershell",
         "params": {
            "script": "build/custom.ps1"
         }
      }
   ],
   "output": {
      /* The output information of execution */
   }
}
```

Por segurança, é necessário haver um arquivo de deploy's permitidos.

```json
[
   { "id": "APP_001", "name": "Application One" },
   { "id": "APP_002", "name": "Application Two" }
]
```
