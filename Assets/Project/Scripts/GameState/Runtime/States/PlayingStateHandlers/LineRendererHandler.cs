using System.Collections.Generic;
using Project.GridSystem.Runtime;
using UnityEngine;

namespace Project.GameState.Runtime
{ 
    public class LineRendererHandler : ILineRendererHandler
    {
        private readonly LineRenderer _lineRenderer;
        private const float LINE_Z_OFFSET = -0.1f;

        public LineRendererHandler(LineRenderer lineRenderer)
        {
            _lineRenderer = lineRenderer;
            InitializeLineRenderer();
        }
 
        public void InitializeLineRenderer()
        {
            if (_lineRenderer == null) return;
            
            _lineRenderer.positionCount = 0;
            _lineRenderer.enabled = false;
        }
 
        public void UpdateSelectionLine(List<GridCell> selectedCells)
        {
            if (_lineRenderer == null || selectedCells == null) return;
             
            _lineRenderer.positionCount = selectedCells.Count;
            
            for (int i = 0; i < selectedCells.Count; i++)
            {
                GridCell cell = selectedCells[i];
                Vector3 cellPos = cell.transform.position; 
                Vector3 adjustedPos = new Vector3(cellPos.x, cellPos.y, cellPos.z + LINE_Z_OFFSET);
                _lineRenderer.SetPosition(i, adjustedPos);
            }
            
            _lineRenderer.enabled = true;
        }
  
        public void HideSelectionLine()
        {
            if (_lineRenderer == null) return;
            
            _lineRenderer.enabled = false;
            _lineRenderer.positionCount = 0;
        }
    }
}